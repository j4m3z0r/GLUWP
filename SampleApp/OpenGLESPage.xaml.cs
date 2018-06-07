using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GLUWP;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpenGLESPage : Page
    {
        private OpenGLES mOpenGLES;

        private EGLSurface mRenderSurface; // This surface is associated with a swapChainPanel on the page
        private object mRenderSurfaceCriticalSection = new object();
        private IAsyncAction mRenderLoopWorker;

        public OpenGLESPage() : this(null)
        {
        }

        internal OpenGLESPage(OpenGLES openGLES)
        {
            mOpenGLES = openGLES;
            mRenderSurface = EGL.NO_SURFACE;
            InitializeComponent();

            Windows.UI.Core.CoreWindow window = Windows.UI.Xaml.Window.Current.CoreWindow;

            window.VisibilityChanged += new TypedEventHandler<CoreWindow, VisibilityChangedEventArgs>((win, args) => OnVisibilityChanged(win, args));

            Loaded += (sender, args) => OnPageLoaded(sender, args);
        }

        ~OpenGLESPage()
        {
            StopRenderLoop();
            DestroyRenderSurface();
        }

        private void OnPageLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // The SwapChainPanel has been created and arranged in the page layout, so EGL can be initialized.
            CreateRenderSurface();
            StartRenderLoop();
        }

        private void OnVisibilityChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.VisibilityChangedEventArgs args)
        {
            if (args.Visible && mRenderSurface != EGL.NO_SURFACE)
            {
                StartRenderLoop();
            }
            else
            {
                StopRenderLoop();
            }
        }

        private void CreateRenderSurface()
        {
            if (mOpenGLES != null && mRenderSurface == EGL.NO_SURFACE)
            {
                // The app can configure the the SwapChainPanel which may boost performance.
                // By default, this template uses the default configuration.
                mRenderSurface = mOpenGLES.CreateSurface(swapChainPanel, null, null);

                // You can configure the SwapChainPanel to render at a lower resolution and be scaled up to
                // the swapchain panel size. This scaling is often free on mobile hardware.
                //
                // One way to configure the SwapChainPanel is to specify precisely which resolution it should render at.
                // Size customRenderSurfaceSize = Size(800, 600);
                // mRenderSurface = mOpenGLES->CreateSurface(swapChainPanel, &customRenderSurfaceSize, nullptr);
                //
                // Another way is to tell the SwapChainPanel to render at a certain scale factor compared to its size.
                // e.g. if the SwapChainPanel is 1920x1280 then setting a factor of 0.5f will make the app render at 960x640
                // float customResolutionScale = 0.5f;
                // mRenderSurface = mOpenGLES->CreateSurface(swapChainPanel, nullptr, &customResolutionScale);
                // 
            }
        }

        private void DestroyRenderSurface()
        {
            if (mOpenGLES != null)
            {
                mOpenGLES.DestroySurface(mRenderSurface);
            }

            mRenderSurface = EGL.NO_SURFACE;
        }

        void RecoverFromLostDevice()
        {
            // Stop the render loop, reset OpenGLES, recreate the render surface
            // and start the render loop again to recover from a lost device.

            StopRenderLoop();

            {
                lock (mRenderSurfaceCriticalSection)
                {
                    DestroyRenderSurface();
                    mOpenGLES.Reset();
                    CreateRenderSurface();
                }
            }

            StartRenderLoop();
        }

        void StartRenderLoop()
        {
            // If the render loop is already running then do not start another thread.
            if (mRenderLoopWorker != null && mRenderLoopWorker.Status == Windows.Foundation.AsyncStatus.Started)
            {
                return;
            }

            // Create a task for rendering that will be run on a background thread.
            var workItemHandler =
                new Windows.System.Threading.WorkItemHandler(action =>
            {
                lock (mRenderSurfaceCriticalSection)
                {
                    mOpenGLES.MakeCurrent(mRenderSurface);
                    SimpleRenderer renderer = new SimpleRenderer();

                    while (action.Status == Windows.Foundation.AsyncStatus.Started)
                    {
                        int panelWidth = 0;
                        int panelHeight = 0;
                        mOpenGLES.GetSurfaceDimensions(mRenderSurface, ref panelWidth, ref panelHeight);

                        // Logic to update the scene could go here
                        renderer.UpdateWindowSize(panelWidth, panelHeight);
                        renderer.Draw();

                        // The call to eglSwapBuffers might not be successful (i.e. due to Device Lost)
                        // If the call fails, then we must reinitialize EGL and the GL resources.
                        if (mOpenGLES.SwapBuffers(mRenderSurface) != EGL.TRUE)
                        {
                            // XAML objects like the SwapChainPanel must only be manipulated on the UI thread.
                            swapChainPanel.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High,
                                new Windows.UI.Core.DispatchedHandler(() =>
                            {
                                RecoverFromLostDevice();
                            }));

                            return;
                        }
                    }
                }
            });

            // Run task on a dedicated high priority background thread.
            mRenderLoopWorker = Windows.System.Threading.ThreadPool.RunAsync(workItemHandler,
                Windows.System.Threading.WorkItemPriority.High,
                Windows.System.Threading.WorkItemOptions.TimeSliced);
        }

        void StopRenderLoop()
        {
            if (mRenderLoopWorker != null)
            {
                mRenderLoopWorker.Cancel();
                mRenderLoopWorker = null;
            }
        }
    }
}

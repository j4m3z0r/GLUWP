using System;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;

namespace GLUWP
{
    public class OpenGLES
    {
        private EGLDisplay mEglDisplay;
        private EGLContext mEglContext;
        private EGLConfig mEglConfig;

        public OpenGLES()
        {
            mEglConfig = null;
            mEglDisplay = EGL.NO_DISPLAY;
            mEglContext = EGL.NO_CONTEXT;
            Initialize();
        }

        ~OpenGLES()
        {
            Cleanup();
        }

        void Initialize()
        {
            int[] configAttributes =
            {
                EGL.RED_SIZE, 8,
                EGL.GREEN_SIZE, 8,
                EGL.BLUE_SIZE, 8,
                EGL.ALPHA_SIZE, 8,
                EGL.DEPTH_SIZE, 8,
                EGL.STENCIL_SIZE, 8,
                EGL.NONE
            };

            int[] contextAttributes =
            {
                EGL.CONTEXT_CLIENT_VERSION, 3,
                EGL.NONE
            };

            int[] defaultDisplayAttributes =
            {
                // These are the default display attributes, used to request ANGLE's D3D11 renderer.
                // eglInitialize will only succeed with these attributes if the hardware supports D3D11 Feature Level 10_0+.
                EGL.PLATFORM_ANGLE_TYPE_ANGLE, EGL.PLATFORM_ANGLE_TYPE_D3D11_ANGLE,

                // EGL.ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER is an optimization that can have large performance benefits on mobile devices.
                // Its syntax is subject to change, though. Please update your Visual Studio templates if you experience compilation issues with it.
                EGL.ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.TRUE,

                // EGL.PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE is an option that enables ANGLE to automatically call 
                // the IDXGIDevice3::Trim method on behalf of the application when it gets suspended. 
                // Calling IDXGIDevice3::Trim when an application is suspended is a Windows Store application certification requirement.
                EGL.PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.TRUE,
                EGL.NONE,
            };

            int[] fl9_3DisplayAttributes =
            {
                // These can be used to request ANGLE's D3D11 renderer, with D3D11 Feature Level 9_3.
                // These attributes are used if the call to eglInitialize fails with the default display attributes.
                EGL.PLATFORM_ANGLE_TYPE_ANGLE, EGL.PLATFORM_ANGLE_TYPE_D3D11_ANGLE,
                EGL.PLATFORM_ANGLE_MAX_VERSION_MAJOR_ANGLE, 9,
                EGL.PLATFORM_ANGLE_MAX_VERSION_MINOR_ANGLE, 3,
                EGL.ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.TRUE,
                EGL.PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.TRUE,
                EGL.NONE,
            };

            int[] warpDisplayAttributes =
            {
                // These attributes can be used to request D3D11 WARP.
                // They are used if eglInitialize fails with both the default display attributes and the 9_3 display attributes.
                EGL.PLATFORM_ANGLE_TYPE_ANGLE, EGL.PLATFORM_ANGLE_TYPE_D3D11_ANGLE,
                EGL.PLATFORM_ANGLE_DEVICE_TYPE_ANGLE, EGL.PLATFORM_ANGLE_DEVICE_TYPE_WARP_ANGLE,
                EGL.ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER, EGL.TRUE,
                EGL.PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE, EGL.TRUE,
                EGL.NONE,
            };

            //
            // To initialize the display, we make three sets of calls to eglGetPlatformDisplayEXT and eglInitialize, with varying 
            // parameters passed to eglGetPlatformDisplayEXT:
            // 1) The first calls uses "defaultDisplayAttributes" as a parameter. This corresponds to D3D11 Feature Level 10_0+.
            // 2) If eglInitialize fails for step 1 (e.g. because 10_0+ isn't supported by the default GPU), then we try again 
            //    using "fl9_3DisplayAttributes". This corresponds to D3D11 Feature Level 9_3.
            // 3) If eglInitialize fails for step 2 (e.g. because 9_3+ isn't supported by the default GPU), then we try again 
            //    using "warpDisplayAttributes".  This corresponds to D3D11 Feature Level 11_0 on WARP, a D3D11 software rasterizer.
            //

            // This tries to initialize EGL to D3D11 Feature Level 10_0+. See above comment for details.
            mEglDisplay =
                EGL.GetPlatformDisplayEXT(EGL.PLATFORM_ANGLE_ANGLE, EGL.DEFAULT_DISPLAY, defaultDisplayAttributes);
            if (mEglDisplay == EGL.NO_DISPLAY)
            {
                throw new ApplicationException("Failed to get EGL display");
            }

            int major = 0, minor = 0;
            if (EGL.Initialize(mEglDisplay, ref major, ref minor) == EGL.FALSE)
            {
                // This tries to initialize EGL to D3D11 Feature Level 9_3, if 10_0+ is unavailable (e.g. on some mobile devices).
                mEglDisplay = EGL.GetPlatformDisplayEXT(EGL.PLATFORM_ANGLE_ANGLE, EGL.DEFAULT_DISPLAY,
                    fl9_3DisplayAttributes);
                if (mEglDisplay == EGL.NO_DISPLAY)
                {
                    throw new ApplicationException("Failed to get EGL display");
                }

                if (EGL.Initialize(mEglDisplay, ref major, ref minor) == EGL.FALSE)
                {
                    // This initializes EGL to D3D11 Feature Level 11_0 on WARP, if 9_3+ is unavailable on the default GPU.
                    mEglDisplay = EGL.GetPlatformDisplayEXT(EGL.PLATFORM_ANGLE_ANGLE, EGL.DEFAULT_DISPLAY,
                        warpDisplayAttributes);
                    if (mEglDisplay == EGL.NO_DISPLAY)
                    {
                        throw new ApplicationException("Failed to get EGL display");
                    }

                    if (EGL.Initialize(mEglDisplay, ref major, ref minor) == EGL.FALSE)
                    {
                        // If all of the calls to eglInitialize returned EGL.FALSE then an error has occurred.
                        throw new ApplicationException("Failed to initialize EGL");
                    }
                }
            }

            int numConfigs = 0;
            var eglConfig = new EGLConfig[1];
            if ((EGL.ChooseConfig(mEglDisplay, configAttributes, eglConfig, ref numConfigs) == EGL.FALSE) ||
                (numConfigs == 0))
            {
                throw new ApplicationException("Failed to choose first EGLConfig");
            }
            else
            {
                mEglConfig = eglConfig[0];
            }

            mEglContext = EGL.CreateContext(mEglDisplay, mEglConfig, EGL.NO_CONTEXT, contextAttributes);
            if (mEglContext == EGL.NO_CONTEXT)
            {
                throw new ApplicationException("Failed to create EGL context");
            }
        }

        void Cleanup()
        {
            if (mEglDisplay != EGL.NO_DISPLAY && mEglContext != EGL.NO_CONTEXT)
            {
                EGL.DestroyContext(mEglDisplay, mEglContext);
                mEglContext = EGL.NO_CONTEXT;
            }

            if (mEglDisplay != EGL.NO_DISPLAY)
            {
                EGL.Terminate(mEglDisplay);
                mEglDisplay = EGL.NO_DISPLAY;
            }
        }

        public void Reset()
        {
            Cleanup();
            Initialize();
        }

        public EGLSurface CreateSurface(SwapChainPanel panel, Size? renderSurfaceSize, float? resolutionScale)
        {
            if (panel == null)
            {
                throw new ArgumentException("SwapChainPanel parameter is invalid");
            }

            if (renderSurfaceSize != null && resolutionScale != null)
            {
                throw new ArgumentException("A size and a scale can't both be specified");
            }

            EGLSurface surface = EGL.NO_SURFACE;

            int[] surfaceAttributes =
            {
                // EGL.ANGLE_SURFACE_RENDER_TO_BACK_BUFFER is part of the same optimization as EGL.ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER (see above).
                // If you have compilation issues with it then please update your Visual Studio templates.
                EGL.ANGLE_SURFACE_RENDER_TO_BACK_BUFFER, EGL.TRUE,
                EGL.NONE
            };

            // Create a PropertySet and initialize with the EGLNativeWindowType.
            PropertySet surfaceCreationProperties = new PropertySet();
            surfaceCreationProperties.Add(ANGLEWindowsStore.EGLNativeWindowTypeProperty, panel);

            // If a render surface size is specified, add it to the surface creation properties
            if (renderSurfaceSize != null)
            {
                surfaceCreationProperties.Add(ANGLEWindowsStore.EGLRenderSurfaceSizeProperty,
                    PropertyValue.CreateSize((Size) renderSurfaceSize));
            }
            
#if TODO
            // If a resolution scale is specified, add it to the surface creation properties
            if (resolutionScale != null)
            {
                surfaceCreationProperties.Add(ANGLEWindowsStore.EGLRenderResolutionScaleProperty,
                    PropertyValue.CreateSingle(resolutionScale));
            }
#endif

            surface = EGL.CreateWindowSurface(mEglDisplay, mEglConfig, surfaceCreationProperties, surfaceAttributes);
            if (surface == EGL.NO_SURFACE)
            {
                throw new ApplicationException("Failed to create EGL surface");
            }

            return surface;
        }

        public void GetSurfaceDimensions(EGLSurface surface, ref int width, ref int height)
        {
            EGL.QuerySurface(mEglDisplay, surface, EGL.WIDTH, ref width);
            EGL.QuerySurface(mEglDisplay, surface, EGL.HEIGHT, ref height);
        }

        public void DestroySurface(EGLSurface surface)
        {
            if (mEglDisplay != EGL.NO_DISPLAY && surface != EGL.NO_SURFACE)
            {
                EGL.DestroySurface(mEglDisplay, surface);
            }
        }

        public void MakeCurrent(EGLSurface surface)
        {
            if (EGL.MakeCurrent(mEglDisplay, surface, surface, mEglContext) == EGL.FALSE)
            {
                throw new ApplicationException("Failed to make EGLSurface current");
            }
        }

        public int SwapBuffers(EGLSurface surface)
        {
            return (EGL.SwapBuffers(mEglDisplay, surface));
        }
    }
}

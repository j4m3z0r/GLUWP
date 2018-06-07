using System;
using System.Runtime.InteropServices;

namespace GLUWP
{
    public partial class EGL
    {
        // from egl.h
        public const int VERSION_1_0 = 1;
        public const int ALPHA_SIZE = 0x3021;
        public const int BAD_ACCESS = 0x3002;
        public const int BAD_ALLOC = 0x3003;
        public const int BAD_ATTRIBUTE = 0x3004;
        public const int BAD_CONFIG = 0x3005;
        public const int BAD_CONTEXT = 0x3006;
        public const int BAD_CURRENT_SURFACE = 0x3007;
        public const int BAD_DISPLAY = 0x3008;
        public const int BAD_MATCH = 0x3009;
        public const int BAD_NATIVE_PIXMAP = 0x300A;
        public const int BAD_NATIVE_WINDOW = 0x300B;
        public const int BAD_PARAMETER = 0x300C;
        public const int BAD_SURFACE = 0x300D;
        public const int BLUE_SIZE = 0x3022;
        public const int BUFFER_SIZE = 0x3020;
        public const int CONFIG_CAVEAT = 0x3027;
        public const int CONFIG_ID = 0x3028;
        public const int CORE_NATIVE_ENGINE = 0x305B;
        public const int DEPTH_SIZE = 0x3025;
        public const int DONT_CARE = -1;
        public const int DRAW = 0x3059;
        public const int EXTENSIONS = 0x3055;
        public const int FALSE = 0;
        public const int GREEN_SIZE = 0x3023;
        public const int HEIGHT = 0x3056;
        public const int LARGEST_PBUFFER = 0x3058;
        public const int LEVEL = 0x3029;
        public const int MAX_PBUFFER_HEIGHT = 0x302A;
        public const int MAX_PBUFFER_PIXELS = 0x302B;
        public const int MAX_PBUFFER_WIDTH = 0x302C;
        public const int NATIVE_RENDERABLE = 0x302D;
        public const int NATIVE_VISUAL_ID = 0x302E;
        public const int NATIVE_VISUAL_TYPE = 0x302F;
        public const int NONE = 0x3038;
        public const int NON_CONFORMANT_CONFIG = 0x3051;
        public const int NOT_INITIALIZED = 0x3001;
        public static readonly EGLContext NO_CONTEXT = EGLContext.Zero;
        public static readonly EGLDisplay NO_DISPLAY = EGLDisplay.Zero;
        public static readonly EGLSurface NO_SURFACE = EGLSurface.Zero;
        public const int PBUFFER_BIT = 0x0001;
        public const int PIXMAP_BIT = 0x0002;
        public const int READ = 0x305A;
        public const int RED_SIZE = 0x3024;
        public const int SAMPLES = 0x3031;
        public const int SAMPLE_BUFFERS = 0x3032;
        public const int SLOW_CONFIG = 0x3050;
        public const int STENCIL_SIZE = 0x3026;
        public const int SUCCESS = 0x3000;
        public const int SURFACE_TYPE = 0x3033;
        public const int TRANSPARENT_BLUE_VALUE = 0x3035;
        public const int TRANSPARENT_GREEN_VALUE = 0x3036;
        public const int TRANSPARENT_RED_VALUE = 0x3037;
        public const int TRANSPARENT_RGB = 0x3052;
        public const int TRANSPARENT_TYPE = 0x3034;
        public const int TRUE = 1;
        public const int VENDOR = 0x3053;
        public const int VERSION = 0x3054;
        public const int WIDTH = 0x3057;
        public const int WINDOW_BIT = 0x0004;
        public const int VERSION_1_1 = 1;
        public const int BACK_BUFFER = 0x3084;
        public const int BIND_TO_TEXTURE_RGB = 0x3039;
        public const int BIND_TO_TEXTURE_RGBA = 0x303A;
        public const int CONTEXT_LOST = 0x300E;
        public const int MIN_SWAP_INTERVAL = 0x303B;
        public const int MAX_SWAP_INTERVAL = 0x303C;
        public const int MIPMAP_TEXTURE = 0x3082;
        public const int MIPMAP_LEVEL = 0x3083;
        public const int NO_TEXTURE = 0x305C;
        public const int TEXTURE_2D = 0x305F;
        public const int TEXTURE_FORMAT = 0x3080;
        public const int TEXTURE_RGB = 0x305D;
        public const int TEXTURE_RGBA = 0x305E;
        public const int TEXTURE_TARGET = 0x3081;
        public const int VERSION_1_2 = 1;
        public const int ALPHA_FORMAT = 0x3088;
        public const int ALPHA_FORMAT_NONPRE = 0x308B;
        public const int ALPHA_FORMAT_PRE = 0x308C;
        public const int ALPHA_MASK_SIZE = 0x303E;
        public const int BUFFER_PRESERVED = 0x3094;
        public const int BUFFER_DESTROYED = 0x3095;
        public const int CLIENT_APIS = 0x308D;
        public const int COLORSPACE = 0x3087;
        public const int COLORSPACE_sRGB = 0x3089;
        public const int COLORSPACE_LINEAR = 0x308A;
        public const int COLOR_BUFFER_TYPE = 0x303F;
        public const int CONTEXT_CLIENT_TYPE = 0x3097;
        public const int DISPLAY_SCALING = 10000;
        public const int HORIZONTAL_RESOLUTION = 0x3090;
        public const int LUMINANCE_BUFFER = 0x308F;
        public const int LUMINANCE_SIZE = 0x303D;
        public const int OPENGL_ES_BIT = 0x0001;
        public const int OPENVG_BIT = 0x0002;
        public const int OPENGL_ES_API = 0x30A0;
        public const int OPENVG_API = 0x30A1;
        public const int OPENVG_IMAGE = 0x3096;
        public const int PIXEL_ASPECT_RATIO = 0x3092;
        public const int RENDERABLE_TYPE = 0x3040;
        public const int RENDER_BUFFER = 0x3086;
        public const int RGB_BUFFER = 0x308E;
        public const int SINGLE_BUFFER = 0x3085;
        public const int SWAP_BEHAVIOR = 0x3093;
        public const int UNKNOWN = -1;
        public const int VERTICAL_RESOLUTION = 0x3091;
        public const int VERSION_1_3 = 1;
        public const int CONFORMANT = 0x3042;
        public const int CONTEXT_CLIENT_VERSION = 0x3098;
        public const int MATCH_NATIVE_PIXMAP = 0x3041;
        public const int OPENGL_ES2_BIT = 0x0004;
        public const int VG_ALPHA_FORMAT = 0x3088;
        public const int VG_ALPHA_FORMAT_NONPRE = 0x308B;
        public const int VG_ALPHA_FORMAT_PRE = 0x308C;
        public const int VG_ALPHA_FORMAT_PRE_BIT = 0x0040;
        public const int VG_COLORSPACE = 0x3087;
        public const int VG_COLORSPACE_sRGB = 0x3089;
        public const int VG_COLORSPACE_LINEAR = 0x308A;
        public const int VG_COLORSPACE_LINEAR_BIT = 0x0020;
        public const int VERSION_1_4 = 1;
        public static readonly EGLNativeDisplayType DEFAULT_DISPLAY = EGLNativeDisplayType.Zero;
        public const int MULTISAMPLE_RESOLVE_BOX_BIT = 0x0200;
        public const int MULTISAMPLE_RESOLVE = 0x3099;
        public const int MULTISAMPLE_RESOLVE_DEFAULT = 0x309A;
        public const int MULTISAMPLE_RESOLVE_BOX = 0x309B;
        public const int OPENGL_API = 0x30A2;
        public const int OPENGL_BIT = 0x0008;
        public const int SWAP_BEHAVIOR_PRESERVED_BIT = 0x0400;
        public const int VERSION_1_5 = 1;
        public const int CONTEXT_MAJOR_VERSION = 0x3098;
        public const int CONTEXT_MINOR_VERSION = 0x30FB;
        public const int CONTEXT_OPENGL_PROFILE_MASK = 0x30FD;
        public const int CONTEXT_OPENGL_RESET_NOTIFICATION_STRATEGY = 0x31BD;
        public const int NO_RESET_NOTIFICATION = 0x31BE;
        public const int LOSE_CONTEXT_ON_RESET = 0x31BF;
        public const int CONTEXT_OPENGL_CORE_PROFILE_BIT = 0x00000001;
        public const int CONTEXT_OPENGL_COMPATIBILITY_PROFILE_BIT = 0x00000002;
        public const int CONTEXT_OPENGL_DEBUG = 0x31B0;
        public const int CONTEXT_OPENGL_FORWARD_COMPATIBLE = 0x31B1;
        public const int CONTEXT_OPENGL_ROBUST_ACCESS = 0x31B2;
        public const int OPENGL_ES3_BIT = 0x00000040;
        public const int CL_EVENT_HANDLE = 0x309C;
        public const int SYNC_CL_EVENT = 0x30FE;
        public const int SYNC_CL_EVENT_COMPLETE = 0x30FF;
        public const int SYNC_PRIOR_COMMANDS_COMPLETE = 0x30F0;
        public const int SYNC_TYPE = 0x30F7;
        public const int SYNC_STATUS = 0x30F1;
        public const int SYNC_CONDITION = 0x30F8;
        public const int SIGNALED = 0x30F2;
        public const int UNSIGNALED = 0x30F3;
        public const int SYNC_FLUSH_COMMANDS_BIT = 0x0001;
        public const ulong FOREVER = 0xFFFFFFFFFFFFFFFFul;
        public const int TIMEOUT_EXPIRED = 0x30F5;
        public const int CONDITION_SATISFIED = 0x30F6;
        public static readonly EGLSync NO_SYNC = EGLSync.Zero;
        public const int SYNC_FENCE = 0x30F9;
        public const int GL_COLORSPACE = 0x309D;
        public const int GL_COLORSPACE_SRGB = 0x3089;
        public const int GL_COLORSPACE_LINEAR = 0x308A;
        public const int GL_RENDERBUFFER = 0x30B9;
        public const int GL_TEXTURE_2D = 0x30B1;
        public const int GL_TEXTURE_LEVEL = 0x30BC;
        public const int GL_TEXTURE_3D = 0x30B2;
        public const int GL_TEXTURE_ZOFFSET = 0x30BD;
        public const int GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x30B3;
        public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x30B4;
        public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x30B5;
        public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x30B6;
        public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x30B7;
        public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x30B8;
        public const int IMAGE_PRESERVED = 0x30D2;
        public static readonly EGLImage NO_IMAGE = EGLImage.Zero;

        private const string libEGL = "libEGL.dll";
        
        [DllImport(libEGL)]
        private static extern IntPtr eglGetPlatformDisplayEXT (
            int platform,
            IntPtr native_display,
            [MarshalAs(UnmanagedType.LPArray)] int[] attrib_list);

        public static EGLDisplay GetPlatformDisplayEXT(int platform, EGLNativeDisplayType native_display, int[] attrib_list)
        {
            return new EGLDisplay(eglGetPlatformDisplayEXT(platform, native_display.Ptr, attrib_list));
        }

        [DllImport(libEGL)]
        private static extern int eglInitialize(IntPtr dpy, ref int major, ref int minor);

        public static int Initialize(EGLDisplay dpy, ref int major, ref int minor)
        {
            return eglInitialize(dpy.Ptr, ref major, ref minor);
        }

        [DllImport(libEGL)]
        private static extern int eglChooseConfig(
            IntPtr dpy,
            [MarshalAs(UnmanagedType.LPArray)] int[] attrib_list,
            [MarshalAs(UnmanagedType.LPArray)][In][Out] IntPtr[] configs,
            int config_size,
            ref int num_config);

        public static int ChooseConfig(EGLDisplay dpy, int[] attrib_list, EGLConfig[] configs, ref int num_config)
        {
            var configPtrs = new IntPtr[configs.Length];
            var result = eglChooseConfig(dpy.Ptr, attrib_list, configPtrs, configPtrs.Length, ref num_config);
            for (var i = 0; i < configPtrs.Length; i++)
            {
                configs[i] = new EGLConfig(configPtrs[i]);
            }

            return result;
        }

        [DllImport(libEGL)]
        private static extern int eglSwapBuffers(IntPtr dpy, IntPtr surface);

        public static int SwapBuffers(EGLDisplay dpy, EGLSurface surface)
        {
            return eglSwapBuffers(dpy.Ptr, surface.Ptr);
        }

        [DllImport(libEGL)]
        private static extern int eglMakeCurrent(IntPtr dpy, IntPtr draw, IntPtr read, IntPtr ctx);

        public static int MakeCurrent(EGLDisplay dpy, EGLSurface draw, EGLSurface read, EGLContext ctx)
        {
            return eglMakeCurrent(dpy.Ptr, draw.Ptr, read.Ptr, ctx.Ptr);
        }

        [DllImport(libEGL)]
        private static extern IntPtr eglCreateContext(
            IntPtr dpy,
            IntPtr config,
            IntPtr share_context,
            [MarshalAs(UnmanagedType.LPArray)] int[] attrib_list);

        public static EGLContext CreateContext(EGLDisplay dpy, EGLConfig config, EGLContext share_context, int[] attrib_list)
        {
            return new EGLContext(eglCreateContext(dpy.Ptr, config.Ptr, share_context.Ptr, attrib_list));
        }

        [DllImport(libEGL)]
        private static extern int eglDestroyContext(IntPtr dpy, IntPtr ctx);

        public static int DestroyContext(EGLDisplay dpy, EGLContext ctx)
        {
            return eglDestroyContext(dpy.Ptr, ctx.Ptr);
        }

        [DllImport(libEGL)]
        private static extern int eglQueryContext(IntPtr display, IntPtr context, int attribute, ref int value);

        public static int QueryContext(EGLDisplay display, EGLContext context, int attribute, ref int value)
        {
            return eglQueryContext(display.Ptr, context.Ptr, attribute, ref value);
        }

        [DllImport(libEGL)]
        private static extern int eglTerminate(IntPtr dpy);

        public static int Terminate(EGLDisplay dpy)
        {
            return eglTerminate(dpy.Ptr);
        }

        [DllImport(libEGL)]
        private static extern int eglQuerySurface(IntPtr dpy, IntPtr surface, int attribute, ref int value);

        public static int QuerySurface(EGLDisplay dpy, EGLSurface surface, int attribute, ref int value)
        {
            return eglQuerySurface(dpy.Ptr, surface.Ptr, attribute, ref value);
        }

        [DllImport(libEGL)]
        private static extern int eglDestroySurface(IntPtr dpy, IntPtr surface);

        public static int DestroySurface(EGLDisplay dpy, EGLSurface surface)
        {
            return eglDestroySurface(dpy.Ptr, surface.Ptr);
        }
        
        [DllImport(libEGL)]
        private static extern IntPtr eglCreateWindowSurface(
            IntPtr dpy, 
            IntPtr config, 
            [MarshalAs(UnmanagedType.IInspectable)] object win, 
            int[] attrib_list);

        public static EGLSurface CreateWindowSurface(
            EGLDisplay dpy,
            EGLConfig config,
            object win,
            int[] attrib_list)
        {
            return new EGLSurface(eglCreateWindowSurface(dpy.Ptr, config.Ptr, win, attrib_list));
        }
    }
}
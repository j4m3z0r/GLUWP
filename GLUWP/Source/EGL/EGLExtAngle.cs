namespace GLUWP
{
    // from eglext_angle.h
    public partial class EGL
    {
        // clang-format off
        public const int ANGLE_robust_resource_initialization = 1;
        public const int ROBUST_RESOURCE_INITIALIZATION_ANGLE = 0x3453;

        public const int ANGLE_keyed_mutex = 1;
        public const int DXGI_KEYED_MUTEX_ANGLE = 0x33A2;

        public const int ANGLE_d3d_texture_client_buffer = 1;
        public const int D3D_TEXTURE_ANGLE = 0x33A3;

        public const int ANGLE_software_display = 1;
        public static readonly EGLNativeDisplayType SOFTWARE_DISPLAY_ANGLE = new EGLNativeDisplayType(-1);

        public const int ANGLE_direct3d_display = 1;
        public static readonly EGLNativeDisplayType D3D11_ELSE_D3D9_DISPLAY_ANGLE = new EGLNativeDisplayType(-2);
        public static readonly EGLNativeDisplayType D3D11_ONLY_DISPLAY_ANGLE = new EGLNativeDisplayType(-3);

         // Only in ms-master for backcompat
        public const int ANGLE_surface_d3d_render_to_back_buffer = 1;
        public const int ANGLE_DISPLAY_ALLOW_RENDER_TO_BACK_BUFFER = 0x320B;
        public const int ANGLE_SURFACE_RENDER_TO_BACK_BUFFER = 0x320C;

        public const int ANGLE_direct_composition = 1;
        public const int DIRECT_COMPOSITION_ANGLE = 0x33A5;

        public const int ANGLE_platform_angle = 1;
        public const int PLATFORM_ANGLE_ANGLE = 0x3202;
        public const int PLATFORM_ANGLE_TYPE_ANGLE = 0x3203;
        public const int PLATFORM_ANGLE_MAX_VERSION_MAJOR_ANGLE = 0x3204;
        public const int PLATFORM_ANGLE_MAX_VERSION_MINOR_ANGLE = 0x3205;
        public const int PLATFORM_ANGLE_TYPE_DEFAULT_ANGLE = 0x3206;
        public const int PLATFORM_ANGLE_DEBUG_LAYERS_ENABLED_ANGLE = 0x3451;

        public const int ANGLE_platform_angle_d3d = 1;
        public const int PLATFORM_ANGLE_TYPE_D3D9_ANGLE = 0x3207;
        public const int PLATFORM_ANGLE_TYPE_D3D11_ANGLE = 0x3208;
        public const int PLATFORM_ANGLE_DEVICE_TYPE_ANGLE = 0x3209;
        public const int PLATFORM_ANGLE_DEVICE_TYPE_HARDWARE_ANGLE = 0x320A;
        public const int PLATFORM_ANGLE_DEVICE_TYPE_WARP_ANGLE = 0x320B;
        public const int PLATFORM_ANGLE_DEVICE_TYPE_REFERENCE_ANGLE = 0x320C;
        public const int PLATFORM_ANGLE_ENABLE_AUTOMATIC_TRIM_ANGLE = 0x320F;

        public const int ANGLE_platform_angle_opengl = 1;
        public const int PLATFORM_ANGLE_TYPE_OPENGL_ANGLE = 0x320D;
        public const int PLATFORM_ANGLE_TYPE_OPENGLES_ANGLE = 0x320E;

        public const int ANGLE_platform_angle_null = 1;
        public const int PLATFORM_ANGLE_TYPE_NULL_ANGLE = 0x33AE;

        public const int ANGLE_platform_angle_vulkan = 1;
        public const int PLATFORM_ANGLE_TYPE_VULKAN_ANGLE = 0x3450;

        public const int X11_VISUAL_ID_ANGLE = 0x33A3;

        public const int ANGLE_flexible_surface_compatibility = 1;
        public const int FLEXIBLE_SURFACE_COMPATIBILITY_SUPPORTED_ANGLE = 0x33A6;

        public const int OPTIMAL_SURFACE_ORIENTATION_ANGLE = 0x33A7;
        public const int SURFACE_ORIENTATION_ANGLE = 0x33A8;
        public const int SURFACE_ORIENTATION_INVERT_X_ANGLE = 0x0001;
        public const int SURFACE_ORIENTATION_INVERT_Y_ANGLE = 0x0002;

        public const int EXPERIMENTAL_PRESENT_PATH_ANGLE = 0x33A4;
        public const int EXPERIMENTAL_PRESENT_PATH_FAST_ANGLE = 0x33A9;
        public const int EXPERIMENTAL_PRESENT_PATH_COPY_ANGLE = 0x33AA;

        public const int D3D_TEXTURE_SUBRESOURCE_ID_ANGLE = 0x33AB;
        //typedef EGLBoolean(EGLAPIENTRYP PFNEGLCREATESTREAMPRODUCERD3DTEXTURENV12ANGLEPROC)(EGLDisplay dpy, EGLStreamKHR stream, const EGLAttrib *attrib_list);
        //typedef EGLBoolean(EGLAPIENTRYP PFNEGLSTREAMPOSTD3DTEXTURENV12ANGLEPROC)(EGLDisplay dpy, EGLStreamKHR stream, void *texture, const EGLAttrib *attrib_list);
        //#ifdef EGLEXT_PROTOTYPES
        //EGLAPI EGLBoolean EGLAPIENTRY eglCreateStreamProducerD3DTextureNV12ANGLE(EGLDisplay dpy, EGLStreamKHR stream, const EGLAttrib *attrib_list);
        //EGLAPI EGLBoolean EGLAPIENTRY eglStreamPostD3DTextureNV12ANGLE(EGLDisplay dpy, EGLStreamKHR stream, void *texture, const EGLAttrib *attrib_list);
        //#endif

        public const int ANGLE_create_context_webgl_compatibility = 1;
        public const int CONTEXT_WEBGL_COMPATIBILITY_ANGLE = 0x3AAC;

        public const int ANGLE_display_texture_share_group = 1;
        public const int DISPLAY_TEXTURE_SHARE_GROUP_ANGLE = 0x3AAF;

        public const int CHROMIUM_create_context_bind_generates_resource = 1;
        public const int CONTEXT_BIND_GENERATES_RESOURCE_CHROMIUM = 0x3AAD;

        public const int ANGLE_create_context_client_arrays = 1;
        public const int CONTEXT_CLIENT_ARRAYS_ENABLED_ANGLE = 0x3452;

        //#ifndef ANGLE_device_creation
        //public const int ANGLE_device_creation 1
        //typedef EGLDeviceEXT(EGLAPIENTRYP PFNEGLCREATEDEVICEANGLEPROC) (EGLint device_type, void *native_device, const EGLAttrib *attrib_list);
        //typedef EGLBoolean(EGLAPIENTRYP PFNEGLRELEASEDEVICEANGLEPROC) (EGLDeviceEXT device);
        //#ifdef EGLEXT_PROTOTYPES
        //EGLAPI EGLDeviceEXT EGLAPIENTRY eglCreateDeviceANGLE(EGLint device_type, void *native_device, const EGLAttrib *attrib_list);
        //EGLAPI EGLBoolean EGLAPIENTRY eglReleaseDeviceANGLE(EGLDeviceEXT device);
        //#endif
        //#endif /* ANGLE_device_creation */

        public const int ANGLE_program_cache_control = 1;
        public const int PROGRAM_CACHE_SIZE_ANGLE = 0x3455;
        public const int PROGRAM_CACHE_KEY_LENGTH_ANGLE = 0x3456;
        public const int PROGRAM_CACHE_RESIZE_ANGLE = 0x3457;
        public const int PROGRAM_CACHE_TRIM_ANGLE = 0x3458;
        public const int CONTEXT_PROGRAM_BINARY_CACHE_ENABLED_ANGLE = 0x3459;
        //typedef EGLint (EGLAPIENTRYP PFNEGLPROGRAMCACHEGETATTRIBANGLEPROC) (EGLDisplay dpy, EGLenum attrib);
        //typedef void (EGLAPIENTRYP PFNEGLPROGRAMCACHEQUERYANGLEPROC) (EGLDisplay dpy, EGLint index, void *key, EGLint *keysize, void *binary, EGLint *binarysize);
        //typedef void (EGLAPIENTRYP PFNEGPROGRAMCACHELPOPULATEANGLEPROC) (EGLDisplay dpy, const void *key, EGLint keysize, const void *binary, EGLint binarysize);
        //typedef EGLint (EGLAPIENTRYP PFNEGLPROGRAMCACHERESIZEANGLEPROC) (EGLDisplay dpy, EGLint limit, EGLenum mode);
        //#ifdef EGLEXT_PROTOTYPES
        //EGLAPI EGLint EGLAPIENTRY eglProgramCacheGetAttribANGLE(EGLDisplay dpy, EGLenum attrib);
        //EGLAPI void EGLAPIENTRY eglProgramCacheQueryANGLE(EGLDisplay dpy, EGLint index, void *key, EGLint *keysize, void *binary, EGLint *binarysize);
        //EGLAPI void EGLAPIENTRY eglProgramCachePopulateANGLE(EGLDisplay dpy, const void *key, EGLint keysize, const void *binary, EGLint binarysize);
        //EGLAPI EGLint EGLAPIENTRY eglProgramCacheResizeANGLE(EGLDisplay dpy, EGLint limit, EGLenum mode);
        //#endif
    }
}
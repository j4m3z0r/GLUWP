using System;

namespace GLUWP
{
    // The following types are all typedef'd to void* in C++
    public class EGLPtr
    {
        internal IntPtr Ptr;

        public EGLPtr(IntPtr p)
        {
            Ptr = p;
        }
    }
    
    public class EGLContext : EGLPtr
    {
        public static EGLContext Zero => new EGLContext(IntPtr.Zero);
        public EGLContext(IntPtr p) : base(p) { }
        public EGLContext(int p) : base(new IntPtr(p)) { }
    }

    public class EGLDisplay : EGLPtr
    {
        public static EGLDisplay Zero => new EGLDisplay(IntPtr.Zero);
        public EGLDisplay(IntPtr p) : base(p) { }
        public EGLDisplay (int p) : base(new IntPtr(p)) { }
    }

    public class EGLSurface : EGLPtr
    {
        public static EGLSurface Zero => new EGLSurface(IntPtr.Zero);
        public EGLSurface(IntPtr p) : base(p) { }
        public EGLSurface(int p) : base(new IntPtr(p)) { }
    }

    public class EGLNativeDisplayType : EGLPtr
    {
        public static EGLNativeDisplayType Zero => new EGLNativeDisplayType(IntPtr.Zero);
        public EGLNativeDisplayType(IntPtr p) : base(p) { }
        public EGLNativeDisplayType(int p) : base(new IntPtr(p)) { }
    }

    public class EGLSync : EGLPtr
    {
        public static EGLSync Zero => new EGLSync(IntPtr.Zero);
        public EGLSync(IntPtr p) : base(p) { }
        public EGLSync(int p) : base(new IntPtr(p)) { }
    }

    public class EGLImage : EGLPtr
    {
        public static EGLImage Zero => new EGLImage(IntPtr.Zero);
        public EGLImage(IntPtr p) : base(p) { }
        public EGLImage(int p) : base(new IntPtr(p)) { }
    }

    public class EGLConfig : EGLPtr
    {
        public static EGLConfig Zero => new EGLConfig(IntPtr.Zero);
        public EGLConfig(IntPtr p) : base(p) { }
        public EGLConfig(int p) : base(new IntPtr(p)) { }
    }
}
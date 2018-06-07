using GLUWP.ES20Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GLUWP.ES20
{
    public class GL
    {
        private const string libGLESv2 = "libGLESv2.dll";

        [DllImport(libGLESv2, EntryPoint = "glCreateShader")]
        public static extern int CreateShader(ShaderType shaderType);

        [DllImport(libGLESv2)]
        private static extern void glShaderSource(int shader, int count, IntPtr[] sources, int[] lengths);

        public static void ShaderSource(int shader, string[] sources)
        {
            var sourceBytePtrs = new List<GCHandle>();
            var sourceLengths = new List<int>();
            foreach (var s in sources)
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                var bytePtr = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                sourceBytePtrs.Add(bytePtr);
                sourceLengths.Add((int) bytes.Length);
            }

            glShaderSource(shader, (int) sourceBytePtrs.Count,
                sourceBytePtrs.Select(p => p.AddrOfPinnedObject()).ToArray(), sourceLengths.ToArray());

            foreach (var p in sourceBytePtrs)
            {
                p.Free();
            }
        }

        public static void ShaderSource(int shader, string source)
        {
            ShaderSource(shader, new string[1] {source});
        }

        [DllImport(libGLESv2)]
        private static extern void glGetShaderInfoLog(
            int shader,
            int maxLength,
            out int length,
            [MarshalAs(UnmanagedType.LPArray)] [Out] byte[] infoLog);

        public static void GetShaderInfoLog(int shader, int bufSz, out int length, out string output)
        {
            var buf = new byte[bufSz];
            glGetShaderInfoLog(shader, bufSz, out length, buf);

            var resultBytes = new byte[length];
            Buffer.BlockCopy(buf, 0, resultBytes, 0, length);
            output = Encoding.UTF8.GetString(resultBytes);
        }

        [DllImport(libGLESv2, EntryPoint = "glGetShaderiv")]
        public static extern void GetShader(int shader, ShaderParameter pname, out int parm);


        [DllImport(libGLESv2, EntryPoint = "glCompileShader")]
        public static extern void CompileShader(int shader);

        [DllImport(libGLESv2)]
        private static extern void glGetShaderiv(int shader, ShaderParameter pname, ref int parms);

        public static int GetShaderiv(int shader, ShaderParameter pname)
        {
            int result = 0;
            glGetShaderiv(shader, pname, ref result);
            return result;
        }

        [DllImport(libGLESv2, EntryPoint = "glCreateProgram")]
        public static extern int CreateProgram();

        [DllImport(libGLESv2, EntryPoint = "glDeleteShader")]
        public static extern void DeleteShader(int shader);

        [DllImport(libGLESv2, EntryPoint = "glDeleteProgram")]
        public static extern void DeleteProgram(int shader);

        [DllImport(libGLESv2, EntryPoint = "glAttachShader")]
        public static extern void AttachShader(int program, int shader);

        [DllImport(libGLESv2, EntryPoint = "glLinkProgram")]
        public static extern void LinkProgram(int program);

        [DllImport(libGLESv2)]
        private static extern void glGetProgramiv(int shader, GetProgramParameterName pname, ref int parms);

        public static int GetProgramiv(int shader, GetProgramParameterName pname)
        {
            int result = 0;
            glGetProgramiv(shader, pname, ref result);
            return result;
        }

        [DllImport(libGLESv2)]
        private static extern void glGetProgramInfoLog(
            int program,
            int maxLength,
            out int length,
            [MarshalAs(UnmanagedType.LPArray)] [Out] byte[] infoLog);

        public static void GetProgramInfoLog(int shader, int bufSz, out int length, out string output)
        {
            var buf = new byte[bufSz];
            glGetProgramInfoLog(shader, bufSz, out length, buf);

            var resultBytes = new byte[length];
            Buffer.BlockCopy(buf, 0, resultBytes, 0, length);
            output = Encoding.UTF8.GetString(resultBytes);
        }

        [DllImport(libGLESv2, EntryPoint = "glGetAttribLocation")]
        public static extern int GetAttribLocation(int program, [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport(libGLESv2, EntryPoint = "glGetUniformLocation")]
        public static extern int GetUniformLocation(int program, [MarshalAs(UnmanagedType.LPStr)] string name);

        #region Buffer methods

        [DllImport(libGLESv2)]
        private static extern void glGenBuffers(int n, [In][Out] int[] buffers);

        public static int[] GenBuffers(int n)
        {
            int[] result = new int[n];
            glGenBuffers(n, result);
            return result;
        }

        [DllImport(libGLESv2, EntryPoint = "glGenBuffers")]
        public static extern void GenBuffers(int n, out int buffers);

        [DllImport(libGLESv2, EntryPoint = "glBindBuffer")]
        public static extern void BindBuffer(BufferTarget target, int buffer);

        [DllImport(libGLESv2)]
        private static extern void glBufferData(BufferTarget target, ulong size, IntPtr data, BufferUsageHint usage);

        public static void BufferData(BufferTarget target, float[] data, BufferUsageHint usage)
        {
            var dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            glBufferData(target, (ulong) (data.Length * sizeof(float)), dataHandle.AddrOfPinnedObject(), usage);
            dataHandle.Free();
        }

        public static void BufferData(BufferTarget target, short[] data, BufferUsageHint usage)
        {
            var dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            glBufferData(target, (ulong) (data.Length * sizeof(short)), dataHandle.AddrOfPinnedObject(), usage);
            dataHandle.Free();
        }

        [DllImport(libGLESv2, EntryPoint = "glBufferData")]
        public static extern void BufferData(BufferTarget target, IntPtr size, float[] data, BufferUsageHint usage);

        [DllImport(libGLESv2, EntryPoint = "glDeleteBuffers")]
        public static extern void DeleteBuffers(int n, int[] buffers);
        #endregion

        #region Texture methods

        [DllImport(libGLESv2)]
        private static extern void glGenTextures(int n, [In][Out] int[] textures);

        public static int[] GenTextures(int n)
        {
            int[] result = new int[n];
            glGenTextures(n, result);
            return result;
        }

        public static int GenTexture()
        {
            return GenTextures(1)[0];
        }

        [DllImport(libGLESv2)]
        private static extern void glDeleteTextures(int n, [In][Out] int[] textures);

        public static void DeleteTextures(int[] textures)
        {
            glDeleteTextures(textures.Length, textures);
        }

        public static void DeleteTexture(int texture)
        {
            DeleteTextures(new int[] {texture});
        }

        [DllImport(libGLESv2, EntryPoint = "glActiveTexture")]
        public static extern void ActiveTexture(TextureUnit texture);

        [DllImport(libGLESv2, EntryPoint = "glBindTexture")]
        public static extern void BindTexture(TextureTarget target, int texture);

        [DllImport(libGLESv2, EntryPoint = "glTexParameteri")]
        public static extern void TexParameter(TextureTarget target, TextureParameterName pname, int param);

        [DllImport(libGLESv2, EntryPoint = "glTexParameterf")]
        public static extern void TexParameter(TextureTarget target, TextureParameterName pname, float param);

        [DllImport(libGLESv2, EntryPoint = "glTexImage2D")]
        public static extern void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat,
            int width, int height, int border, PixelFormat format, PixelType type, byte[] data);

        [DllImport(libGLESv2, EntryPoint = "glTexSubImage2D")]
        public static extern void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width,
            int height, PixelFormat format, PixelType type, byte[] data);

        #endregion

        [DllImport(libGLESv2, EntryPoint = "glEnable")]
        public static extern void Enable(EnableCap cap);

        [DllImport(libGLESv2, EntryPoint = "glUseProgram")]
        public static extern void UseProgram(int program);

        #region Vertex attributes

        [DllImport(libGLESv2, EntryPoint = "glEnableVertexAttribArray")]
        public static extern void EnableVertexAttribArray(int index);

        [DllImport(libGLESv2, EntryPoint = "glDisableVertexAttribArray")]
        public static extern void DisableVertexAttribArray(int index);

        [DllImport(libGLESv2)]
        private static extern void glVertexAttribPointer(int index, int size, VertexAttribPointerType type,
            bool normalized, int stride, IntPtr pointer);

        public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized,
            int stride, int offset)
        {
            glVertexAttribPointer(index, size, type, normalized, stride, new IntPtr(offset));
        }

        #endregion

        #region Draw methods

        [DllImport(libGLESv2)]
        private static extern void glDrawElements(BeginMode mode, int count, DrawElementsType type, IntPtr indices);

        public static void DrawElements(BeginMode mode, int count, DrawElementsType type, uint indices)
        {
            glDrawElements(mode, count, type, new IntPtr(indices));
        }

        [DllImport(libGLESv2, EntryPoint = "glDrawArrays")]
        public static extern void DrawArrays(BeginMode mode, int first, int count);

        #endregion

        #region Uniform methods

        [DllImport(libGLESv2, EntryPoint = "glUniform1f")]
        public static extern void Uniform1(int location, float v0);

        [DllImport(libGLESv2, EntryPoint = "glUniform2f")]
        public static extern void Uniform2(int location, float v0, float v1);

        [DllImport(libGLESv2, EntryPoint = "glUniform3f")]
        public static extern void Uniform3(int location, float v0, float v1, float v2);

        [DllImport(libGLESv2, EntryPoint = "glUniform4f")]
        public static extern void Uniform4(int location, float v0, float v1, float v2, float v3);

        [DllImport(libGLESv2, EntryPoint = "glUniform1i")]
        public static extern void Uniform1(int location, int v0);

        [DllImport(libGLESv2, EntryPoint = "glUniform2i")]
        public static extern void Uniform2(int location, int v0, int v1);

        [DllImport(libGLESv2, EntryPoint = "glUniform3i")]
        public static extern void Uniform3(int location, int v0, int v1, int v2);

        [DllImport(libGLESv2, EntryPoint = "glUniform4i")]
        public static extern void Uniform4(int location, int v0, int v1, int v2, int v3);

        [DllImport(libGLESv2, EntryPoint = "glUniformMatrix2fv")]
        public static extern void UniformMatrix2(int location, int count, bool transpose, float[] value);

        [DllImport(libGLESv2, EntryPoint = "glUniformMatrix3fv")]
        public static extern void UniformMatrix3(int location, int count, bool transpose, float[] value);

        [DllImport(libGLESv2, EntryPoint = "glUniformMatrix4fv")]
        public static extern void UniformMatrix4(int location, int count, bool transpose, float[] value);

        #endregion

        #region Misc utility methods

        [DllImport(libGLESv2, EntryPoint = "glViewport")]
        public static extern void Viewport(int x, int y, int width, int height);

        [DllImport(libGLESv2, EntryPoint = "glGetError")]
        public static extern ErrorCode GetError();

        [DllImport(libGLESv2, EntryPoint = "glGetIntegerv")]
        public static extern int GetInteger(GetPName property, out int val);

        [DllImport(libGLESv2, EntryPoint = "glFlush")]
        public static extern void Flush();

        #endregion

        #region Clear methods

        [DllImport(libGLESv2, EntryPoint = "glClearColor")]
        public static extern void ClearColor(float r, float g, float b, float a);

        [DllImport(libGLESv2, EntryPoint = "glClear")]
        public static extern void Clear(int mask);

        [DllImport(libGLESv2, EntryPoint = "glClear")]
        public static extern void Clear(ClearBufferMask mask);

        #endregion

        #region Blending methods

        [DllImport(libGLESv2, EntryPoint = "glBlendFunc")]
        public static extern void BlendFunc(BlendingFactorSrc src, BlendingFactorDest dst);

        [DllImport(libGLESv2, EntryPoint = "glBlendEquation")]
        public static extern void BlendEquation(BlendEquationMode mode);

        #endregion
    }
}
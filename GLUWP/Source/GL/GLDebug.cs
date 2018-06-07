using System;
using System.Diagnostics;
using GLUWP.ES20Enums;

/// <summary>
/// This is a wrapper around the standard ES20.GL class that calls GetError after every call and will break into the
/// debugger if an error is returned.
/// </summary>
namespace GLUWP.ES20Debug
{
    public class GL
    {
        private static void CheckError()
        {
            var err = ES20.GL.GetError();
            if (err != ErrorCode.NoError)
            {
                Debugger.Break();
            }
            ES20.GL.Flush();
        }

        public static int CreateShader(ShaderType shaderType)
        {
            var ret = ES20.GL.CreateShader(shaderType);
            CheckError();
            return ret;
        }

        public static void ShaderSource(int shader, string[] sources)
        {
            ES20.GL.ShaderSource(shader, sources);
            CheckError();
        }

        public static void ShaderSource(int shader, string source)
        {
            ES20.GL.ShaderSource(shader, source);
            CheckError();
        }

        public static void GetShaderInfoLog(int shader, int bufSz, out int length, out string output)
        {
            ES20.GL.GetShaderInfoLog(shader, bufSz, out length, out output);
            CheckError();
        }

        public static void GetShader(int shader, ShaderParameter pname, out int parm)
        {
            ES20.GL.GetShader(shader, pname, out parm);
            CheckError();
        }

        public static void CompileShader(int shader)
        {
            ES20.GL.CompileShader(shader);
            CheckError();
        }

        public static int GetShaderiv(int shader, ShaderParameter pname)
        {
            var ret = ES20.GL.GetShaderiv(shader, pname);
            CheckError();
            return ret;
        }

        public static int CreateProgram()
        {
            var ret = ES20.GL.CreateProgram();
            CheckError();
            return ret;
        }

        public static void DeleteShader(int shader)
        {
            ES20.GL.DeleteShader(shader);
            CheckError();
        }

        public static void DeleteProgram(int shader)
        {
            ES20.GL.DeleteProgram(shader);
            CheckError();
        }

        public static void AttachShader(int program, int shader)
        {
            ES20.GL.AttachShader(program, shader);
            CheckError();
        }

        public static void LinkProgram(int program)
        {
            ES20.GL.LinkProgram(program);
            CheckError();
        }

        public static int GetProgramiv(int shader, GetProgramParameterName pname)
        {
            var ret = ES20.GL.GetProgramiv(shader, pname);
            CheckError();
            return ret;
        }

        public static void GetProgramInfoLog(int shader, int bufSz, out int length, out string output)
        {
            ES20.GL.GetProgramInfoLog(shader, bufSz, out length, out output);
            CheckError();
        }

        public static int GetAttribLocation(int program, string name)
        {
            var ret = ES20.GL.GetAttribLocation(program, name);
            CheckError();
            return ret;
        }

        public static int GetUniformLocation(int program, string name)
        {
            var ret = ES20.GL.GetUniformLocation(program, name);
            CheckError();
            return ret;
        }

        public static int[] GenBuffers(int n)
        {
            var ret = ES20.GL.GenBuffers(n);
            CheckError();
            return ret;
        }

        public static void GenBuffers(int n, out int buffers)
        {
            ES20.GL.GenBuffers(n, out buffers);
            CheckError();
        }

        public static void BindBuffer(BufferTarget target, int buffer)
        {
            ES20.GL.BindBuffer(target, buffer);
            CheckError();
        }

        public static void BufferData(BufferTarget target, float[] data, BufferUsageHint usage)
        {
            ES20.GL.BufferData(target, data, usage);
            CheckError();
        }

        public static void BufferData(BufferTarget target, short[] data, BufferUsageHint usage)
        {
            ES20.GL.BufferData(target, data, usage);
            CheckError();
        }

        public static void BufferData(BufferTarget target, IntPtr size, float[] data, BufferUsageHint usage)
        {
            ES20.GL.BufferData(target, size, data, usage);
            CheckError();
        }

        public static void DeleteBuffers(int n, int[] buffers)
        {
            ES20.GL.DeleteBuffers(n, buffers);
            CheckError();
        }

        public static int[] GenTextures(int n)
        {
            var ret = ES20.GL.GenTextures(n);
            CheckError();

            foreach (var tex in ret)
            {
                if (tex == 0)
                {
                    Debugger.Break();
                }
            }
            return ret;
        }

        public static int GenTexture()
        {
            var ret = ES20.GL.GenTexture();
            if (ret == 0)
            {
                Debugger.Break();
            }
            CheckError();
            return ret;
        }

        public static void DeleteTextures(int[] textures)
        {
            ES20.GL.DeleteTextures(textures);
            CheckError();
        }

        public static void DeleteTexture(int texture)
        {
            ES20.GL.DeleteTexture(texture);
            CheckError();
        }

        public static void ActiveTexture(TextureUnit texture)
        {
            ES20.GL.ActiveTexture(texture);
            CheckError();
        }

        public static void BindTexture(TextureTarget target, int texture)
        {
            ES20.GL.BindTexture(target, texture);
            CheckError();
        }

        public static void TexParameter(TextureTarget target, TextureParameterName pname, int param)
        {
            ES20.GL.TexParameter(target, pname, param);
            CheckError();
        }

        public static void TexParameter(TextureTarget target, TextureParameterName pname, float param)
        {
            ES20.GL.TexParameter(target, pname, param);
            CheckError();
        }

        public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalFormat,
            int width, int height, int border, PixelFormat format, PixelType type, byte[] data)
        {
            ES20.GL.TexImage2D(target, level, internalFormat, width, height, border, format, type, data);
            CheckError();
        }

        public static void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset,
            int width, int height, PixelFormat format, PixelType type, byte[] data)
        {
            ES20.GL.TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, data);
            CheckError();
        }

        public static void Enable(EnableCap cap)
        {
            ES20.GL.Enable(cap);
            CheckError();
        }

        public static void UseProgram(int program)
        {
            ES20.GL.UseProgram(program);
            CheckError();
        }

        public static void EnableVertexAttribArray(int index)
        {
            ES20.GL.EnableVertexAttribArray(index);
            CheckError();
        }

        public static void DisableVertexAttribArray(int index)
        {
            ES20.GL.DisableVertexAttribArray(index);
            CheckError();
        }

        public static void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized,
            int stride, int offset)
        {
            ES20.GL.VertexAttribPointer(index, size, type, normalized, stride, offset);
            CheckError();
        }

        public static void DrawElements(BeginMode mode, int count, DrawElementsType type, uint indices)
        {
            ES20.GL.DrawElements(mode, count, type, indices);
            CheckError();
        }
        
        public static void DrawArrays(BeginMode mode, int first, int count)
        {
            ES20.GL.DrawArrays(mode, first, count);
            CheckError();
        }

        public static void Uniform1(int location, float v0)
        {
            ES20.GL.Uniform1(location, v0);
            CheckError();
        }
        
        public static void Uniform2(int location, float v0, float v1)
        {
            ES20.GL.Uniform2(location, v0, v1);
            CheckError();
        }
        
        public static void Uniform3(int location, float v0, float v1, float v2)
        {
            ES20.GL.Uniform3(location, v0, v1, v2);
            CheckError();
        }
        
        public static void Uniform4(int location, float v0, float v1, float v2, float v3)
        {
            ES20.GL.Uniform4(location, v0, v1, v2, v3);
            CheckError(); 
        }

        public static void Uniform1(int location, int v0)
        {
            ES20.GL.Uniform1(location, v0);
            CheckError(); 
        }
        public static void Uniform2(int location, int v0, int v1)
        {
            ES20.GL.Uniform2(location, v0, v1);
            CheckError(); 
        }
        public static void Uniform3(int location, int v0, int v1, int v2)
        {
            ES20.GL.Uniform3(location, v0, v1, v2);
            CheckError(); 
        }
        public static void Uniform4(int location, int v0, int v1, int v2, int v3)
        {
            ES20.GL.Uniform4(location, v0, v1, v2, v3);
            CheckError(); 
        }

        public static void UniformMatrix2(int location, int count, bool transpose, float[] value)
        {
            ES20.GL.UniformMatrix2(location, count, transpose, value);
            CheckError();
        }
        
        public static void UniformMatrix3(int location, int count, bool transpose, float[] value)
        {
            ES20.GL.UniformMatrix3(location, count, transpose, value);
            CheckError();
        }
        
        public static void UniformMatrix4(int location, int count, bool transpose, float[] value)
        {
            ES20.GL.UniformMatrix4(location, count, transpose, value);
            CheckError();
        }

        public static void Viewport(int x, int y, int width, int height)
        {
            ES20.GL.Viewport(x, y, width, height);
            CheckError();
        }

        public static ErrorCode GetError()
        {
            return ES20.GL.GetError();
        }

        public static int GetInteger(GetPName property, out int val)
        {
            var ret = ES20.GL.GetInteger(property, out val);
            CheckError();
            return ret;
        }

        public static void Flush()
        {
            ES20.GL.Flush();
            CheckError();
        }

        public static void ClearColor(float r, float g, float b, float a)
        {
            ES20.GL.ClearColor(r, g, b, a);
            CheckError();
        }

        public static void Clear(int mask)
        {
            ES20.GL.Clear(mask);
            CheckError();
        }

        public static void Clear(ClearBufferMask mask)
        {
            ES20.GL.Clear(mask);
            CheckError();
        }

        public static void BlendFunc(BlendingFactorSrc src, BlendingFactorDest dst)
        {
            ES20.GL.BlendFunc(src, dst);
            CheckError();
        }

        public static void BlendEquation(BlendEquationMode mode)
        {
            ES20.GL.BlendEquation(mode);
            CheckError();
        }
    }
}

using System;
using GLUWP.ES20;
using GLUWP.ES20Enums;

namespace SampleApp
{
    public class SimpleRenderer
    {
        private int mProgram;
        private int mWindowWidth;
        private int mWindowHeight;

        private int mPositionAttribLocation;
        private int mColorAttribLocation;

        private int mModelUniformLocation;
        private int mViewUniformLocation;
        private int mProjUniformLocation;

        private int mVertexPositionBuffer;
        private int mVertexColorBuffer;
        private int mIndexBuffer;

        int mDrawCount;

        private int CompileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);

            string[] sourceArray = new string[] { source };
            GL.ShaderSource(shader, sourceArray);
            
            GL.CompileShader(shader);

            int compileResult = GL.GetShaderiv(shader, ShaderParameter.CompileStatus);


            if (compileResult == 0)
            {
                int infoLogLength = GL.GetShaderiv(shader, ShaderParameter.InfoLogLength);

                string infoLog;
                GL.GetShaderInfoLog(shader, infoLogLength, out int length, out infoLog);

                var errorMessage = $"Shader compilation failed: {infoLog}";

                throw new ApplicationException(errorMessage);
            }

            return shader;
        }

        int CompileProgram(string vsSource, string fsSource)
        {
            int program = GL.CreateProgram();

            if (program == 0)
            {
                throw new ApplicationException("Program creation failed");
            }

            int vs = CompileShader(ShaderType.VertexShader, vsSource);
            int fs = CompileShader(ShaderType.FragmentShader, fsSource);

            if (vs == 0 || fs == 0)
            {
                GL.DeleteShader(fs);
                GL.DeleteShader(vs);
                GL.DeleteProgram(program);
                return 0;
            }

            GL.AttachShader(program, vs);
            GL.DeleteShader(vs);

            GL.AttachShader(program, fs);
            GL.DeleteShader(fs);

            GL.LinkProgram(program);

            int linkStatus = GL.GetProgramiv(program, GetProgramParameterName.LinkStatus);

            if (linkStatus == 0)
            {
                var infoLogLength = GL.GetProgramiv(program, GetProgramParameterName.InfoLogLength);

                string infoLog;
                GL.GetProgramInfoLog(program, infoLogLength, out int length, out infoLog);

                var errorMessage = $"Program link failed: {infoLog}";

                throw new ApplicationException(errorMessage);
            }


            return program;
        }

        public SimpleRenderer()
        {
            mWindowWidth = 0;
            mWindowHeight = 0;
            mDrawCount = 0;
            
            // Vertex Shader source
            string vs = @"
                uniform mat4 uModelMatrix;
                uniform mat4 uViewMatrix;
                uniform mat4 uProjMatrix;
                attribute vec4 aPosition;
                attribute vec4 aColor;
                varying vec4 vColor;
                void main()
                {
                    gl_Position = uProjMatrix * uViewMatrix * uModelMatrix * aPosition;
                    vColor = aColor;
                }
            ";

            // Fragment Shader source
            string fs = @"
                precision mediump float;
                varying vec4 vColor;
                void main()
                {
                    gl_FragColor = vColor;
                }
            ";

            // Set up the shader and its uniform/attribute locations.
            mProgram = CompileProgram(vs, fs);
            mPositionAttribLocation = GL.GetAttribLocation(mProgram, "aPosition");
            mColorAttribLocation = GL.GetAttribLocation(mProgram, "aColor");
            mModelUniformLocation = GL.GetUniformLocation(mProgram, "uModelMatrix");
            mViewUniformLocation = GL.GetUniformLocation(mProgram, "uViewMatrix");
            mProjUniformLocation = GL.GetUniformLocation(mProgram, "uProjMatrix");

            // Then set up the cube geometry.
            float[] vertexPositions = 
            {
                -1.0f, -1.0f, -1.0f,
                -1.0f, -1.0f,  1.0f,
                -1.0f,  1.0f, -1.0f,
                -1.0f,  1.0f,  1.0f,
                 1.0f, -1.0f, -1.0f,
                 1.0f, -1.0f,  1.0f,
                 1.0f,  1.0f, -1.0f,
                 1.0f,  1.0f,  1.0f,
            };

            mVertexPositionBuffer = GL.GenBuffers(1)[0];
            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexPositionBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexPositions, BufferUsageHint.StaticDraw);

            float[] vertexColors =
            {
                0.0f, 0.0f, 0.0f,
                0.0f, 0.0f, 1.0f,
                0.0f, 1.0f, 0.0f,
                0.0f, 1.0f, 1.0f,
                1.0f, 0.0f, 0.0f,
                1.0f, 0.0f, 1.0f,
                1.0f, 1.0f, 0.0f,
                1.0f, 1.0f, 1.0f,
            };

            mVertexColorBuffer = GL.GenBuffers(1)[0];
            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexColorBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexColors, BufferUsageHint.StaticDraw);

            short[] indices =
            {
                0, 1, 2, // -x
                1, 3, 2,

                4, 6, 5, // +x
                5, 6, 7,

                0, 5, 1, // -y
                0, 4, 5,

                2, 7, 6, // +y
                2, 3, 7,

                0, 6, 4, // -z
                0, 2, 6,

                1, 7, 3, // +z
                1, 5, 7,
            };

            mIndexBuffer = GL.GenBuffers(1)[0];
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mIndexBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices, BufferUsageHint.StaticDraw);
        }

        ~SimpleRenderer()
        {
            if (mProgram != 0)
            {
                GL.DeleteProgram(mProgram);
                mProgram = 0;
            }

            if (mVertexPositionBuffer != 0)
            {
                GL.DeleteBuffers(1, new int[]{ mVertexPositionBuffer });
                mVertexPositionBuffer = 0;
            }

            if (mVertexColorBuffer != 0)
            {
                GL.DeleteBuffers(1, new int[] {mVertexColorBuffer});
                mVertexColorBuffer = 0;
            }

            if (mIndexBuffer != 0)
            {
                GL.DeleteBuffers(1, new int[] {mIndexBuffer});
                mIndexBuffer = 0;
            }
        }

        public void Draw()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (mProgram == 0)
                return;

            GL.UseProgram(mProgram);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexPositionBuffer);
            GL.EnableVertexAttribArray(mPositionAttribLocation);
            GL.VertexAttribPointer(mPositionAttribLocation, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, mVertexColorBuffer);
            GL.EnableVertexAttribArray(mColorAttribLocation);
            GL.VertexAttribPointer(mColorAttribLocation, 3, VertexAttribPointerType.Float, false, 0, 0);

            var modelMatrix = MathHelper.SimpleModelMatrix((float)mDrawCount / 50.0f);
            GL.UniformMatrix4(mModelUniformLocation, 1, false, modelMatrix.m);

            var viewMatrix = MathHelper.SimpleViewMatrix();
            GL.UniformMatrix4(mViewUniformLocation, 1, false, viewMatrix.m);

            var projectionMatrix = MathHelper.SimpleProjectionMatrix((float)mWindowWidth / (float)mWindowHeight);
            GL.UniformMatrix4(mProjUniformLocation, 1, false, projectionMatrix.m);

            // Draw 36 indices: six faces, two triangles per face, 3 indices per triangle
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mIndexBuffer);
            GL.DrawElements(BeginMode.Triangles, (6 * 2) * 3, DrawElementsType.UnsignedShort, 0);

            mDrawCount += 1;
        }

        public void UpdateWindowSize(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
            mWindowWidth = width;
            mWindowHeight = height;
        }
    }
}

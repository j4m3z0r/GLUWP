using System;

namespace SampleApp
{
    public class Matrix4
    {
        public float[] m;

        public Matrix4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            m = new float[]
            {
                m00, m01, m02, m03,
                m10, m11, m12, m13,
                m20, m21, m22, m23,
                m30, m31, m32, m33
            };
        }
    }

    public class MathHelper
    {
        public static Matrix4 SimpleModelMatrix(float radians)
        {
            float cosine = (float) Math.Cos(radians);
            float sine = (float) Math.Sin(radians);

            return new Matrix4(
                cosine, 0.0f,  -sine, 0.0f,
                  0.0f, 1.0f ,  0.0f, 0.0f,
                  sine, 0.0f, cosine, 0.0f,
                  0.0f, 0.0f,   0.0f, 1.0f);
        }

        public static Matrix4 SimpleViewMatrix()
        {
            // Camera is at 60 degrees to the ground, in the YZ plane.
            // Camera Look-At is hardcoded to (0, 0, 0).
            // Camera Up is hardcoded to (0, 1, 0).
            const float sqrt3over2 = 0.86603f;
            const float cameraDistance = 5.0f;

            return new Matrix4(
                1.0f,       0.0f,            0.0f, 0.0f,
                0.0f, sqrt3over2,            0.5f, 0.0f,
                0.0f,      -0.5f,      sqrt3over2, 0.0f,
                0.0f,       0.0f, -cameraDistance, 1.0f);
        }

        public static Matrix4 SimpleProjectionMatrix(float aspectRatio)
        {
            // Far plane is at 50.0f, near plane is at 1.0f.
            // FoV is hardcoded to pi/3.
            float cotangent = 1f / (float) Math.Tan(3.14159f / 6.0f);

            return new Matrix4(
                cotangent / aspectRatio,      0.0f,                    0.0f,                             0.0f,
                                   0.0f, cotangent,                    0.0f,                             0.0f,
                                   0.0f,      0.0f, -50.0f / (50.0f - 1.0f), (-50.0f * 1.0f) / (50.0f - 1.0f),
                                   0.0f,      0.0f,                   -1.0f,                            0.0f);
        }

    }
}

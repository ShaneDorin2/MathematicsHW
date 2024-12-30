using MatrixUnitTestsHW;
using NUnit.Framework;
using System;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    public struct Quaternion
    {
        // Exercices 23 ----------------------------------------------------------------------------------------

        public float x, y, z, w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Quaternion Identity => new Quaternion(0, 0, 0, 1);

        // Exercices 24 ----------------------------------------------------------------------------------------

        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {

            float magnitude = (float)Math.Sqrt(axis.X * axis.X + axis.Y * axis.Y + axis.Z * axis.Z);
            if (magnitude == 0)
            {
                throw new ArgumentException("Axis must be non-zero.");
            }
            Vector3 normalizedAxis = new Vector3(axis.X / magnitude, axis.Y / magnitude, axis.Z / magnitude);

            System.Numerics.Quaternion solQuat = System.Numerics.Quaternion.CreateFromAxisAngle(normalizedAxis, (float)(angle * Math.PI / 180));
            return new Quaternion(solQuat.X, solQuat.Y, solQuat.Z, solQuat.W);
        }

        // Exercices 25 ----------------------------------------------------------------------------------------

        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            System.Numerics.Quaternion leftQuat = new System.Numerics.Quaternion(left.x, left.y, left.z, left.w);
            System.Numerics.Quaternion rightQuat = new System.Numerics.Quaternion(right.x, right.y, right.z, right.w);
            System.Numerics.Quaternion solQuat = leftQuat * rightQuat;
            return new Quaternion(solQuat.X, solQuat.Y, solQuat.Z, solQuat.W);
        }

        // Exercices 26 ----------------------------------------------------------------------------------------

        public static Vector3 operator *(Quaternion left, Vector3 vec)
        {
            System.Numerics.Quaternion leftQuat = new System.Numerics.Quaternion(left.x, left.y, left.z, left.w);
            System.Numerics.Quaternion rightVecQuat = new System.Numerics.Quaternion(vec, 0);
            System.Numerics.Quaternion solQuat = leftQuat * rightVecQuat * System.Numerics.Quaternion.Inverse(leftQuat);
            return new Vector3(solQuat.X, solQuat.Y, solQuat.Z);
        }

        // Exercices 27 ----------------------------------------------------------------------------------------

        public MatrixFloat Matrix { get 
            { 
                return Quat2RotMatrix(this);
            } 
        }

        public static MatrixFloat Quat2RotMatrix(Quaternion quat)
        {
            MatrixFloat solMat = MatrixFloat.Identity(4);

            float xx = quat.x * quat.x;
            float yy = quat.y * quat.y;
            float zz = quat.z * quat.z;
            float xy = quat.x * quat.y;
            float xz = quat.x * quat.z;
            float yz = quat.y * quat.z;
            float wx = quat.w * quat.x;
            float wy = quat.w * quat.y;
            float wz = quat.w * quat.z;

            solMat[0, 0] = 1 - 2 * (yy + zz);
            solMat[0, 1] = 2 * (xy - wz);
            solMat[0, 2] = 2 * (xz + wy);

            solMat[1, 0] = 2 * (xy + wz);
            solMat[1, 1] = 1 - 2 * (xx + zz);
            solMat[1, 2] = 2 * (yz - wx);

            solMat[2, 0] = 2 * (xz - wy);
            solMat[2, 1] = 2 * (yz + wx);
            solMat[2, 2] = 1 - 2 * (xx + yy);

            return solMat;
        }

        // Exercices 28 ----------------------------------------------------------------------------------------

        public static Quaternion Euler(float x, float y, float z)
        {
            return Quaternion.AngleAxis(y, new Vector3(0, 1, 0)) *
                   Quaternion.AngleAxis(x, new Vector3(1, 0, 0)) *
                   Quaternion.AngleAxis(z, new Vector3(0, 0, 1));
        }

        public Vector3 EulerAngles { get
            {
                MatrixFloat rotMat = this.Matrix;

                float sy = (float)Math.Sqrt(rotMat[0, 0] * rotMat[0, 0] + rotMat[1, 0] * rotMat[1, 0]);

                float p = (float)Math.Asin(-rotMat[1, 2]) * (180f / (float)Math.PI);
                float h = (float)Math.Atan2(rotMat[0, 2], rotMat[2, 2]) * (180f / (float)Math.PI);
                float b = (float)Math.Atan2(rotMat[1, 0], rotMat[1, 1]) * (180f / (float)Math.PI);

                if ((float)Math.Cos(p) == 0)
                {

                    p = (float)Math.Asin(-rotMat[1, 2]) * (180f / (float)Math.PI);
                    h = (float)Math.Atan2(-rotMat[2, 0], rotMat[0, 0]) * (180f / (float)Math.PI);
                    b = 0;

                }
                TestContext.WriteLine(p + "-" + h + "-" + b);
                return new Vector3(p, h, b);
            } 
        }
    }
}   
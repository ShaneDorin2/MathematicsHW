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
    }
}
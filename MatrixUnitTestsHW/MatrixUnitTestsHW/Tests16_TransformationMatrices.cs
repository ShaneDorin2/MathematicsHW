using System;
using System.Numerics;
using MatrixUnitTestsHW;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests16_TransformationMatrices
    {
        [Test]
        public void TestTranslatePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            ClassicAssert.AreEqual(vTransformed.X, 6f);
            ClassicAssert.AreEqual(vTransformed.Y, 3f);
            ClassicAssert.AreEqual(vTransformed.Z, 1f);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestTranslateDirection()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 0f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });
            Vector4 vTransformed = m * v;

            ClassicAssert.AreEqual(1f, vTransformed.X);
            ClassicAssert.AreEqual(0f, vTransformed.Y);
            ClassicAssert.AreEqual(0f, vTransformed.Z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(0f, vTransformedInverted.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.34d)] // shhhhh...
        public void TestScalePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(2f, 1f, 3f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 0.5f, 0f, 0f, 0f },
                { 0.0f, 2f, 0f, 0f },
                { 0.0f, 0f, 3f, 0f },
                { 0.0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            ClassicAssert.AreEqual(1f, vTransformed.X);
            ClassicAssert.AreEqual(2f, vTransformed.Y);
            ClassicAssert.AreEqual(9f, vTransformed.Z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            ClassicAssert.AreEqual(2f, vTransformedInverted.X);
            ClassicAssert.AreEqual(1f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(3f, vTransformedInverted.Z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            ClassicAssert.AreEqual(2f, vTransformedInverted.X);
            ClassicAssert.AreEqual(1f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(3f, vTransformedInverted.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestRotatePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 4f, 7f, 1f);
            double a = Math.PI / 2d;
            float cosA = (float)Math.Cos(a);
            float sinA = (float)Math.Sin(a);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { cosA, -sinA, 0f, 0f },
                { sinA, cosA, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            ClassicAssert.AreEqual(-4f, vTransformed.X);
            ClassicAssert.AreEqual(1f, vTransformed.Y);
            ClassicAssert.AreEqual(7f, vTransformed.Z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(4f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(7f, vTransformedInverted.Z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            ClassicAssert.AreEqual(1f, vTransformedInverted.X);
            ClassicAssert.AreEqual(4f, vTransformedInverted.Y);
            ClassicAssert.AreEqual(7f, vTransformedInverted.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
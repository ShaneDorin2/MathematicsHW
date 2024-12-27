using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests19_TransformLocalScale
    {
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Default Scale
            ClassicAssert.AreEqual(1f, t.LocalScale.X);
            ClassicAssert.AreEqual(1f, t.LocalScale.Y);
            ClassicAssert.AreEqual(1f, t.LocalScale.Z);
            
            //Default Matrix
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeScale()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            ClassicAssert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
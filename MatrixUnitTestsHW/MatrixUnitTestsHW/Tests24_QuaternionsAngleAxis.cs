using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests24_QuaternionsAngleAxis
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisX()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around X axis
            float angle = 90f;
            Vector3 axis = new Vector3(1f, 0f, 0f);
            Tests.Quaternion q = Tests.Quaternion.AngleAxis(angle, axis);
            ClassicAssert.AreEqual(0.71f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(0.71f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisY()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around Y axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 1f, 0f);
            Tests.Quaternion q = Tests.Quaternion.AngleAxis(angle, axis);
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0.71f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(0.71f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisZ()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around Z axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 0f, 1f);
            Tests.Quaternion q = Tests.Quaternion.AngleAxis(angle, axis);
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0.71f, q.z);
            ClassicAssert.AreEqual(0.71f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionCustomAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //60 degree around Vector(0,3,4)
            float angle = 60f;
            Vector3 axis = new Vector3(0f, 3f, 4f);
            Tests.Quaternion q = Tests.Quaternion.AngleAxis(angle, axis);
            ClassicAssert.AreEqual(0f, q.x);   
            ClassicAssert.AreEqual(0.3f, q.y);
            ClassicAssert.AreEqual(0.4f, q.z);
            ClassicAssert.AreEqual(0.87f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
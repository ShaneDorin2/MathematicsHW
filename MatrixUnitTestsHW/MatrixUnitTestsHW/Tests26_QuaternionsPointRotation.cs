using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests26_QuaternionsPointRotation
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionPointRotation1()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Vector3 point = new Vector3(1f, 0f, 0f);
            Quaternion rotateZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Vector3 rotatedPoint = rotateZAxis * point;
            
            ClassicAssert.AreEqual(0f, rotatedPoint.X);
            ClassicAssert.AreEqual(1f, rotatedPoint.Y);
            ClassicAssert.AreEqual(0f, rotatedPoint.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionPointRotation2()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Vector3 point = new Vector3(0f, 2f, 1f);
            Quaternion rotateXAxis = Quaternion.AngleAxis(45f, new Vector3(1f, 0f, 0f));

            Vector3 rotatedPoint = rotateXAxis * point;
            
            ClassicAssert.AreEqual(0f, rotatedPoint.X);
            ClassicAssert.AreEqual(0.71f, rotatedPoint.Y);
            ClassicAssert.AreEqual(2.12f, rotatedPoint.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
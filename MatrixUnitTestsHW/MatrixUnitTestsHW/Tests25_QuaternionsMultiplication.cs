using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests25_QuaternionsMultiplication
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            ClassicAssert.AreEqual(0.5f, result.x);
            ClassicAssert.AreEqual(0.5f, result.y);
            ClassicAssert.AreEqual(0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            result = rotationYAxis * rotationXAxis;
            ClassicAssert.AreEqual(0.5f, result.x);
            ClassicAssert.AreEqual(0.5f, result.y);
            ClassicAssert.AreEqual(-0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            ClassicAssert.AreEqual(0.5f, result.x);
            ClassicAssert.AreEqual(-0.5f, result.y);
            ClassicAssert.AreEqual(0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationXAxis;
            ClassicAssert.AreEqual(0.5f, result.x);
            ClassicAssert.AreEqual(0.5f, result.y);
            ClassicAssert.AreEqual(0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            ClassicAssert.AreEqual(0.5f, result.x);
            ClassicAssert.AreEqual(0.5f, result.y);
            ClassicAssert.AreEqual(0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationYAxis;
            ClassicAssert.AreEqual(-0.5f, result.x);
            ClassicAssert.AreEqual(0.5f, result.y);
            ClassicAssert.AreEqual(0.5f, result.z);
            ClassicAssert.AreEqual(0.5f, result.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyIdentity()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            ClassicAssert.AreEqual(0f, result.x);
            ClassicAssert.AreEqual(0.71f, result.y);
            ClassicAssert.AreEqual(0f, result.z);
            ClassicAssert.AreEqual(0.71f, result.w);

            result = qIdentity * rotationYAxis;
            ClassicAssert.AreEqual(0f, result.x);
            ClassicAssert.AreEqual(0.71f, result.y);
            ClassicAssert.AreEqual(0f, result.z);
            ClassicAssert.AreEqual(0.71f, result.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
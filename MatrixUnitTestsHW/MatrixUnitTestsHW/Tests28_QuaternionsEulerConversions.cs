using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests28_QuaternionsEulerConversions
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionFromEulerCustomAxis1()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            
            //Quaternion Euler : Return the product of quaternions with the following order
            //qRY: Quaternion that rotates y degrees around y axis (0,1,0)
            //qRX: Quaternion that rotates x degrees around x axis (1,0,0)
            //qRZ: Quaternion that rotates z degrees around z axis (0,0,1)
            //So the final equation is => q = qRY * qRX * qRZ
            Quaternion q = Quaternion.Euler(30f, 45f, 90f);
            
            ClassicAssert.AreEqual(0.430f, q.x);
            ClassicAssert.AreEqual(0.092f, q.y);
            ClassicAssert.AreEqual(0.561f, q.z);
            ClassicAssert.AreEqual(0.701f, q.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionToEulerCustomAxis1()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            //You can use Quaternion Matrix to retrieve the euler angles
            //See this video for more info => https://youtu.be/vxPVw_EgyJI
            Quaternion q = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
            Vector3 eulerAngles = q.EulerAngles;
            ClassicAssert.AreEqual(30f, eulerAngles.X);
            ClassicAssert.AreEqual(45f, eulerAngles.Y);
            ClassicAssert.AreEqual(90f, eulerAngles.Z);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionFromEulerCustomAxis2()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            
            Quaternion q = Quaternion.Euler(45f, 0f, 90f);
            
            ClassicAssert.AreEqual(0.271, q.x);
            ClassicAssert.AreEqual(-0.271f, q.y);
            ClassicAssert.AreEqual(0.653f, q.z);
            ClassicAssert.AreEqual(0.653f, q.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestQuaternionToEulerCustomAxis2()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Quaternion q = new Quaternion(0.271f, -0.271f, 0.653f, 0.653f);
            Vector3 eulerAngles = q.EulerAngles;
            ClassicAssert.AreEqual(45f, eulerAngles.X);
            ClassicAssert.AreEqual(0f, eulerAngles.Y);
            ClassicAssert.AreEqual(90f, eulerAngles.Z);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
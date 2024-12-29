using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests23_NewQuaternions
    {
        [Test]
        public void TestNewQuaternion()
        {
            Tests.Quaternion q = new Tests.Quaternion(0f, 0.71f, 0f, 0.71f);
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0.71f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(0.71f, q.w);
        }
        
        [Test]
        public void TestNewQuaternionFromAnother()
        {
            Tests.Quaternion q1 = new Tests.Quaternion(0f, 0.71f, 0f, 0.71f);
            Tests.Quaternion q2 = q1;
            q2.x = 0.71f;

            ClassicAssert.AreEqual(0.71f, q2.x);
            ClassicAssert.AreEqual(0.71f, q2.y);
            ClassicAssert.AreEqual(0f, q2.z);
            ClassicAssert.AreEqual(0.71f, q2.w);
            
            ClassicAssert.AreEqual(0f, q1.x);
            ClassicAssert.AreEqual(0.71f, q1.y);
            ClassicAssert.AreEqual(0f, q1.z);
            ClassicAssert.AreEqual(0.71f, q1.w);
        }
        
        [Test]
        public void TestQuaternionIdentity()
        {
            //An identity quantity is a Tests.Quaternion with no rotation
            Tests.Quaternion q = Tests.Quaternion.Identity;
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(1f, q.w);
        }
    }
}
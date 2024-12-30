using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests29_TransformGetLocalRotationAsQuaternion
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestTransformGetLocalRotationQuaternionDefault()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Transform t = new Transform();
            
            Quaternion q = t.LocalRotationQuaternion;
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(1f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            ClassicAssert.AreEqual(0.259f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(0.966f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 30f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0.259f, q.y);
            ClassicAssert.AreEqual(0f, q.z);
            ClassicAssert.AreEqual(0.966f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 0f, 30f);
            
            Quaternion q = t.LocalRotationQuaternion;
            ClassicAssert.AreEqual(0f, q.x);
            ClassicAssert.AreEqual(0f, q.y);
            ClassicAssert.AreEqual(0.259f, q.z);
            ClassicAssert.AreEqual(0.966f, q.w);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            
            Quaternion q = t.LocalRotationQuaternion;
            ClassicAssert.AreEqual(0.430f, q.x);
            ClassicAssert.AreEqual(0.092f, q.y);
            ClassicAssert.AreEqual(0.561f, q.z);
            ClassicAssert.AreEqual(0.701f, q.w);
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
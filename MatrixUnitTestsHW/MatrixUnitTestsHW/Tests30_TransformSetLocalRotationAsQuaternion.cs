using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests30_TransformSetLocalRotationAsQuaternion
    {
        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.259f, 0f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            ClassicAssert.AreEqual(30f, localRotation.X);
            ClassicAssert.AreEqual(0f, localRotation.Y);
            ClassicAssert.AreEqual(0f, localRotation.Z);
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0.259f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            ClassicAssert.AreEqual(0f, localRotation.X);
            ClassicAssert.AreEqual(30f, localRotation.Y);
            ClassicAssert.AreEqual(0f, localRotation.Z);
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0f, 0.259f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            ClassicAssert.AreEqual(0f, localRotation.X);
            ClassicAssert.AreEqual(0f, localRotation.Y);
            ClassicAssert.AreEqual(30f, localRotation.Z);
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
            
            Vector3 localRotation = t.LocalRotation;
            ClassicAssert.AreEqual(30f, localRotation.X);
            ClassicAssert.AreEqual(45f, localRotation.Y);
            ClassicAssert.AreEqual(90f, localRotation.Z);

            ClassicAssert.AreEqual(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.707f, 0f, 0.707f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.707f, 0f, 0.707f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0f, -1f, 0f, 0f },
                { 1f, 0f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());
            
           // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
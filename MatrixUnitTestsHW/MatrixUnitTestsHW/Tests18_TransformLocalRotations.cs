using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests18_TransformLocalRotations
    {
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //Default Rotation
            ClassicAssert.AreEqual(0f, t.LocalRotation.X);
            ClassicAssert.AreEqual(0f, t.LocalRotation.Y);
            ClassicAssert.AreEqual(0f, t.LocalRotation.Z);

            //Default Matrices
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
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            t.LocalRotation = new Vector3(30f, 0f, 0f);
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
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 30f, 0f);
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 0f, 30f);
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //For LocalRotationMatrix attribute =>
            //Rotations are performed around the Z axis, the X axis, and the Y axis, in that order.
            //Like Unity => https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
            //So the operation order is => RY * RX * RZ

            //Rotation to Multiple Axis
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            ClassicAssert.AreEqual(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
    }
}
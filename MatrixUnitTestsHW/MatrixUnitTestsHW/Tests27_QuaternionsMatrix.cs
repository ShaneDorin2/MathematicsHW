using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests27_QuaternionsMatrix
    {
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            ClassicAssert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            ClassicAssert.AreEqual(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, result.Matrix.ToArray2D());

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            ClassicAssert.AreEqual(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, invertedResult.Matrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.01d)]
          public void TestQuaternionMatrixIdentity()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.Identity;
            
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

    }
}
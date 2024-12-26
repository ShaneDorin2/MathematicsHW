using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests17_TransformLocalPosition
    {
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //Default Position
            ClassicAssert.AreEqual(0f, t.LocalPosition.X);
            ClassicAssert.AreEqual(0f, t.LocalPosition.Y);
            ClassicAssert.AreEqual(0f, t.LocalPosition.Z);

            //Default Translation Matrix
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalTranslationMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformChangePosition()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //Translation
            t.LocalPosition = new Vector3(5f, 2f, 1f);
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 2f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalTranslationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
    }
}
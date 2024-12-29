using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests22_TransformChangeWorldPosition
    {
        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeWorldPosition()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform t = new Transform();
            t.WorldPosition = new Vector3(100f, 1f, 42f);

            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 100f },
                { 0f, 1f, 0f, 1f },
                { 0f, 0f, 1f, 42f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalToWorldMatrix.ToArray2D());

            ClassicAssert.AreEqual(100f, t.LocalPosition.X);
            ClassicAssert.AreEqual(1f, t.LocalPosition.Y);
            ClassicAssert.AreEqual(42f, t.LocalPosition.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeWorldPositionInsideParent()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(100f, 1f, 42f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            ClassicAssert.AreEqual(-100f, tChild.LocalPosition.X);
            ClassicAssert.AreEqual(-1f, tChild.LocalPosition.Y);
            ClassicAssert.AreEqual(-42f, tChild.LocalPosition.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeWorldPositionInsideParentWithRotation()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(20f, 0f, 0f);
            tParent.LocalRotation = new Vector3(0f, 0f, 45f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            ClassicAssert.AreEqual(new[,]
            {
                { 0.707f, -0.707f, 0f, 0f },
                { 0.707f, 0.707f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            ClassicAssert.AreEqual(-14.142f, tChild.LocalPosition.X);
            ClassicAssert.AreEqual(14.142f, tChild.LocalPosition.Y);
            ClassicAssert.AreEqual(0f, tChild.LocalPosition.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        [DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeWorldPositionInsideParentWithScale()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(200, -10f, 9f);
            tParent.LocalScale = new Vector3(2f, 4f, 6f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            ClassicAssert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 4f, 0f, 0f },
                { 0f, 0f, 6f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            ClassicAssert.AreEqual(-100f, tChild.LocalPosition.X);
            ClassicAssert.AreEqual(2.5f, tChild.LocalPosition.Y);
            ClassicAssert.AreEqual(-1.5f, tChild.LocalPosition.Z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
using MatrixUnitTestsHW;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests03_IdentityMatrices
    {
        [Test]
        public void TestGenerateIdentityMatrices()
        {
            MatrixInt identity2 = MatrixInt.Identity(2);
            ClassicAssert.AreEqual(new[,]
            {
                { 1, 0 },
                { 0, 1 },
            }, identity2.ToArray2D());

            MatrixInt identity3 = MatrixInt.Identity(3);
            ClassicAssert.AreEqual(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 },
            }, identity3.ToArray2D());

            MatrixInt identity4 = MatrixInt.Identity(4);
            ClassicAssert.AreEqual(new[,]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            }, identity4.ToArray2D());
        }

        [Test]
        public void TestMatricesIsIdentity()
        {
            MatrixInt identity2 = new MatrixInt(new[,]
            {
                { 1, 0 },
                { 0, 1 }
            });
            ClassicAssert.IsTrue(identity2.IsIdentity());

            MatrixInt identity3 = new MatrixInt(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            });
            ClassicAssert.IsTrue(identity3.IsIdentity());

            MatrixInt notSameColumnsAndLines = new MatrixInt(new[,]
            {
                { 1, 0, 0 },
                { 0, 1, 0 }
            });
            ClassicAssert.IsFalse(notSameColumnsAndLines.IsIdentity());

            MatrixInt notIdentity1 = new MatrixInt(new[,]
            {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 },
            });
            ClassicAssert.IsFalse(notIdentity1.IsIdentity());

            MatrixInt notIdentity2 = new MatrixInt(new[,]
            {
                { 1, 0, 4 },
                { 0, 1, 0 },
                { 0, 0, 1 },
            });
            ClassicAssert.IsFalse(notIdentity2.IsIdentity());
        }
    }
}
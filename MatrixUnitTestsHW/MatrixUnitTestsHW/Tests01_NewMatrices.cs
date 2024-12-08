using MatrixUnitTestsHW;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests01_NewMatrices
    {
        [Test]
        public void TestNewEmptyMatrices()
        {
            MatrixInt m1 = new MatrixInt(3, 2);
            ClassicAssert.AreEqual(new[,]
            {
                { 0, 0 },
                { 0, 0 },
                { 0, 0 }
            }, m1.ToArray2D());
            ClassicAssert.AreEqual(3, m1.NbLines);
            ClassicAssert.AreEqual(2, m1.NbColumns);

            MatrixInt m2 = new MatrixInt(2, 3);
            ClassicAssert.AreEqual(new[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
            }, m2.ToArray2D());
            ClassicAssert.AreEqual(2, m2.NbLines);
            ClassicAssert.AreEqual(3, m2.NbColumns);
        }

        [Test]
        public void TestNewMatricesFrom2DArray()
        {
            //See GetLength documentation to retrieve length of a multi-dimensional array
            //https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength
            MatrixInt m = new MatrixInt(new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                }
            );
            ClassicAssert.AreEqual(3, m.NbLines);
            ClassicAssert.AreEqual(3, m.NbColumns);

            //See Indexers Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/indexers/
            ClassicAssert.AreEqual(1, m[0, 0]);
            ClassicAssert.AreEqual(2, m[0, 1]);
            ClassicAssert.AreEqual(3, m[0, 2]);
            ClassicAssert.AreEqual(4, m[1, 0]);
            ClassicAssert.AreEqual(5, m[1, 1]);
            ClassicAssert.AreEqual(6, m[1, 2]);
            ClassicAssert.AreEqual(7, m[2, 0]);
            ClassicAssert.AreEqual(8, m[2, 1]);
            ClassicAssert.AreEqual(9, m[2, 2]);
        }
    }
}
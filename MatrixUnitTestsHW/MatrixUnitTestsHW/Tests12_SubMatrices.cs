﻿using MatrixUnitTestsHW;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests12_SubMatrices
    {
        [Test]
        public void TestGetSubMatricesInstance()
        {
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 6f, 8f, 9f },
                { 17f, 0f, 1f },
                { 23f, 4f, 1f }
            });

            MatrixFloat subMatrix_0_0 = m.SubMatrix(0, 0);
            ClassicAssert.AreEqual(new[,]
            {
                { 0f, 1f },
                { 4f, 1f },
            }, subMatrix_0_0.ToArray2D());

            MatrixFloat subMatrix_0_1 = m.SubMatrix(0, 1);
            ClassicAssert.AreEqual(new[,]
            {
                { 17f, 1f },
                { 23f, 1f },
            }, subMatrix_0_1.ToArray2D());

            MatrixFloat subMatrix_0_2 = m.SubMatrix(0, 2);
            ClassicAssert.AreEqual(new[,]
            {
                { 17f, 0f },
                { 23f, 4f },
            }, subMatrix_0_2.ToArray2D());

            MatrixFloat subMatrix_1_0 = m.SubMatrix(1, 0);
            ClassicAssert.AreEqual(new[,]
            {
                { 8f, 9f },
                { 4f, 1f },
            }, subMatrix_1_0.ToArray2D());

            MatrixFloat subMatrix_1_1 = m.SubMatrix(1, 1);
            ClassicAssert.AreEqual(new[,]
            {
                { 6f, 9f },
                { 23f, 1f },
            }, subMatrix_1_1.ToArray2D());

            MatrixFloat subMatrix_1_2 = m.SubMatrix(1, 2);
            ClassicAssert.AreEqual(new[,]
            {
                { 6f, 8f },
                { 23f, 4f },
            }, subMatrix_1_2.ToArray2D());

            MatrixFloat subMatrix_2_0 = m.SubMatrix(2, 0);
            ClassicAssert.AreEqual(new[,]
            {
                { 8f, 9f },
                { 0f, 1f },
            }, subMatrix_2_0.ToArray2D());

            MatrixFloat subMatrix_2_1 = m.SubMatrix(2, 1);
            ClassicAssert.AreEqual(new[,]
            {
                { 6f, 9f },
                { 17f, 1f },
            }, subMatrix_2_1.ToArray2D());

            MatrixFloat subMatrix_2_2 = m.SubMatrix(2, 2);
            ClassicAssert.AreEqual(new[,]
            {
                { 6f, 8f },
                { 17f, 0f },
            }, subMatrix_2_2.ToArray2D());
        }

        [Test]
        public void TestGetSubMatricesStatic()
        {
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f }
            });

            MatrixFloat subMatrix_0_0 = MatrixFloat.SubMatrix(m, 0, 0);
            ClassicAssert.AreEqual(new[,]
            {
                { 5f, 6f },
                { 8f, 9f },
            }, subMatrix_0_0.ToArray2D());
            
            MatrixFloat subMatrix_1_2 = MatrixFloat.SubMatrix(m, 1, 0);
            ClassicAssert.AreEqual(new[,]
            {
                { 2f, 3f },
                { 8f, 9f },
            }, subMatrix_1_2.ToArray2D());
            
            MatrixFloat subMatrix_2_1 = MatrixFloat.SubMatrix(m, 2, 1);
            ClassicAssert.AreEqual(new[,]
            {
                { 1f, 3f },
                { 4f, 6f },
            }, subMatrix_2_1.ToArray2D());
            
            MatrixFloat subMatrix_0_2 = MatrixFloat.SubMatrix(m, 0, 2);
            ClassicAssert.AreEqual(new[,]
            {
                { 4f, 5f },
                { 7f, 8f },
            }, subMatrix_0_2.ToArray2D());
        }
    }
}
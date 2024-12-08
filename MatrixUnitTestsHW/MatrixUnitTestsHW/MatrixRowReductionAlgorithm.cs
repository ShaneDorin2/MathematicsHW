using MatrixUnitTestsHW;
using NUnit.Framework;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Web;
using static MatrixUnitTestsHW.MatrixFloat;

namespace Maths_Matrices.Tests
{
    internal class MatrixRowReductionAlgorithm
    {
        public static (MatrixFloat, MatrixFloat) Apply(MatrixFloat transformationMax, MatrixFloat solutionMax)
        {
            MatrixFloat augMatrix = MatrixFloat.GenerateAugmentedMatrix(transformationMax, solutionMax);


            for (int pos = 0; pos < augMatrix.NbLines; pos++)
            {
                float holder = OrganizeMatrix(augMatrix, pos);
                TestContext.WriteLine("holder is {0}.",holder);
                if (holder == 0 && solutionMax.NbColumns >1) throw new MatrixInvertException();
                if (holder == 0) continue;

                MatrixElementaryOperations.MultiplyLineF(augMatrix, pos, 1 / augMatrix[pos, pos]);
                for (int i = 0; i < augMatrix.NbLines; i++)
                {
                    if (i == pos) continue;
                    float subHolder = augMatrix[i, pos];
                    for (int e = 0; e < augMatrix.NbColumns; e++)
                    {
                        augMatrix[i, e] -= subHolder * augMatrix[pos, e];
                    }
                }
            }
            return augMatrix.Split(transformationMax.NbColumns-1);
        }

        public static float OrganizeMatrix(MatrixFloat augMatrix, int pos)
        {
            if (pos >= augMatrix.NbLines) return augMatrix[pos, pos];

            float highestStorage = augMatrix[pos, pos];
            int highestIndexStroage = pos;
            for (int i = pos; i < augMatrix.NbLines; i++)
            {
                if ((highestStorage == 0 || augMatrix[i, pos] > highestStorage) && augMatrix[i, pos] != 0) highestIndexStroage = i;
            }
            if (highestIndexStroage == pos) return augMatrix[pos, pos];
            MatrixElementaryOperations.SwapLinesF(augMatrix, pos, highestIndexStroage);
            return highestStorage;
        }
    }
}
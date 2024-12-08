using Maths_Matrices.Tests;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUnitTestsHW
{
    public class MatrixFloat
    {
        // Exercices 10 ----------------------------------------------------------------------------------------

        float[,] matrix;

        public MatrixFloat(int numOfRows, int numOfCols)
        {
            if (numOfRows <= 0 || numOfCols <= 0) { throw new Exception("Invalid parameters. Must be positive numbers."); }
            this.matrix = new float[numOfRows, numOfCols];
        }

        public MatrixFloat(float[,] Array2D)
        {
            this.matrix = Array2D;
        }

        public MatrixFloat(MatrixFloat matrix)
        {
            this.matrix = matrix.ToArray2D();
        }

        public float[,] ToArray2D()
        {
            //return matrix;
            return (float[,])matrix.Clone();
        }

        public int NbLines { get { return matrix.GetLength(0); } }
        public int NbColumns { get { return matrix.GetLength(1); } }

        public float this[int row, int col]
        {
            get => matrix[row, col];
            set => matrix[row, col] = value;
        }

        // ----------------------------------------------------------------------------------------

        public static MatrixFloat Identity(int size)
        {
            MatrixFloat identityMax = new MatrixFloat(size, size);
            for (int i = 0; i < identityMax.NbLines; i++)
            {
                for (int e = 0; e < identityMax.NbColumns; e++)
                {
                    if (i == e) { identityMax[i, e] = 1f; }
                }
            }
            return identityMax;
        }

        public bool IsIdentity()
        {
            if (NbLines != NbColumns) return false;
            for (int i = 0; i < NbLines; i++)
            {
                for (int e = 0; e < NbColumns; e++)
                {
                    if (i == e && this[i, e] != 1f) { return false; }
                    if (i != e && this[i, e] != 0f) { return false; }
                }
            }
            return true;
        }

        //  ----------------------------------------------------------------------------------------

        public void Multiply(float factor)
        {
            for (int i = 0; i < NbLines; i++)
            {
                for (int e = 0; e < NbColumns; e++)
                {
                    this[i, e] *= factor;
                }
            }
        }

        public static MatrixFloat Multiply(MatrixFloat matrix, float factor)
        {
            MatrixFloat productMatrix = new MatrixFloat(matrix);
            productMatrix.Multiply(factor);
            return productMatrix;
        }

        public static MatrixFloat operator *(MatrixFloat matrix, int factor) => Multiply(matrix, factor);
        public static MatrixFloat operator *(int factor, MatrixFloat matrix) => Multiply(matrix, factor);

        public static MatrixFloat operator -(MatrixFloat matrix)
        {
            for (int i = 0; i < matrix.NbLines; i++)
            {
                for (int e = 0; e < matrix.NbColumns; e++)
                {
                    matrix[i, e] *= -1;
                }
            }
            return matrix;
        }

        //  ----------------------------------------------------------------------------------------

        public void Add(MatrixFloat addendMatrix)
        {
            if (NbLines != addendMatrix.NbLines || NbColumns != addendMatrix.NbColumns) throw new MatrixSumException();
            for (int i = 0; i < NbLines; i++)
            {
                for (int e = 0; e < NbColumns; e++)
                {
                    this[i, e] += addendMatrix[i, e];
                }
            }
        }

        public static MatrixFloat Add(MatrixFloat matrixA, MatrixFloat matrixB)
        {
            MatrixFloat sumMatrix = new MatrixFloat(matrixA);
            sumMatrix.Add(matrixB);
            return sumMatrix;
        }

        public static MatrixFloat operator +(MatrixFloat matrixA, MatrixFloat matrixB) => Add(matrixA, matrixB);

        public static MatrixFloat operator -(MatrixFloat matrixA, MatrixFloat matrixB)
        {
            MatrixFloat differenceMatrix = new MatrixFloat(matrixA);
            for (int i = 0; i < differenceMatrix.NbLines; i++)
            {
                for (int e = 0; e < differenceMatrix.NbColumns; e++)
                {
                    differenceMatrix[i, e] -= matrixB[i, e];
                }
            }
            return differenceMatrix;
        }

        //  ----------------------------------------------------------------------------------------

        public MatrixFloat Multiply(MatrixFloat factorMatrix)
        {
            if (this.NbColumns != factorMatrix.NbLines) throw new MatrixMultiplyException();

            MatrixFloat productMatrix = new MatrixFloat(this.NbLines, factorMatrix.NbColumns);
            for (int i = 0; i < productMatrix.NbColumns; i++)
            {
                for (int e = 0; e < productMatrix.NbLines; e++)
                {
                    for (int j = 0; j < this.NbColumns; j++)
                    {
                        //TestContext.WriteLine("{0}.{1}.{2}", i, e, j);
                        productMatrix[e, i] += this[e, j] * factorMatrix[j, i];
                    }
                }
            }
            return productMatrix;
        }

        public static MatrixFloat Multiply(MatrixFloat matrixA, MatrixFloat matrixB)
        {
            MatrixFloat productMatrix = new MatrixFloat(matrixA.Multiply(matrixB));
            return matrixA.Multiply(matrixB);
        }

        public static MatrixFloat operator *(MatrixFloat matrixA, MatrixFloat matrixB) => Multiply(matrixA, matrixB);

        //  ----------------------------------------------------------------------------------------

        public MatrixFloat Transpose()
        {
            MatrixFloat transMatrix = new MatrixFloat(NbColumns, NbLines);
            for (int i = 0; i < NbColumns; i++)
            {
                for (int e = 0; e < NbLines; e++)
                {
                    transMatrix[i, e] = this[e, i];
                }
            }
            return transMatrix;
        }

        public static MatrixFloat Transpose(MatrixFloat matrix) => new MatrixFloat(matrix.Transpose());

        //  ----------------------------------------------------------------------------------------

        public static MatrixFloat GenerateAugmentedMatrix(MatrixFloat transformationMatrix, MatrixFloat smallerMatrix)
        {
            MatrixFloat augMatrix = new MatrixFloat(transformationMatrix.NbLines, transformationMatrix.NbColumns + smallerMatrix.NbColumns);
            for (int i = 0; i < augMatrix.NbColumns; i++)
            {
                for (int e = 0; e < augMatrix.NbLines; e++)
                {
                    if (i >= transformationMatrix.NbColumns) augMatrix[e, i] = smallerMatrix[e, i-transformationMatrix.NbColumns];
                    else augMatrix[e, i] = transformationMatrix[e, i];
                }
            }
            return augMatrix;
        }

        public (MatrixFloat, MatrixFloat) Split(int colNum)
        {
            MatrixFloat leftMax = new MatrixFloat(NbLines, colNum + 1);
            MatrixFloat rightMax = new MatrixFloat(NbLines, NbColumns - (colNum + 1));

            for (int i = 0; i < NbColumns; i++)
            {
                for (int e = 0; e < NbLines; e++)
                {
                    //TestContext.WriteLine("{0}.{1}", i, e);
                    if (i <= colNum) leftMax[e, i] = this[e, i];
                    else rightMax[e, i - (colNum + 1)] = this[e, i];
                }
            }
            return (leftMax, rightMax);
        }

        // Exercice 11 ---------------------------------------------------------------------------------------- 

        internal MatrixFloat InvertByRowReduction()
        {
            MatrixFloat max;
            MatrixFloat solMax = MatrixFloat.Identity(NbColumns);
            (max, solMax) = MatrixRowReductionAlgorithm.Apply(this, solMax);
            return solMax;
        }

        public static MatrixFloat InvertByRowReduction(MatrixFloat matrix) => matrix.InvertByRowReduction();

        // Exercice 12 ---------------------------------------------------------------------------------------- 

        internal MatrixFloat SubMatrix(int v1, int v2)
        {
            MatrixFloat solMax = new MatrixFloat(NbLines-1, NbColumns-1);
            for (int i = 0; i < NbColumns; i++)
            {
                if (i == v1) continue; 
                for (int e = 0; e < NbLines; e++)
                {
                    if (e == v2) continue;
                    solMax[i < v1 ? i : i-1, 
                           e < v2 ? e : e-1] = this[i, e];
                }
            }
            return solMax;
        }

        internal static MatrixFloat SubMatrix(MatrixFloat m, int v1, int v2) => m.SubMatrix(v1, v2);

        // Exercice 13 ---------------------------------------------------------------------------------------- 

        internal static float Determinant(MatrixFloat m) //recursive
        {
            if (m.NbLines == 2)
            {
                float num = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];
                return num;
            }
            
            float solution = 0;

            for (int i = 0; i < m.NbColumns; i++)
            {
                bool isEven = (i % 2 == 0);
                solution += Determinant(m.SubMatrix(i, 0)) * (isEven ? 1 : -1) * m[i, 0];
            }
            return (float)Math.Round(solution);
        }

        // Exercice 14 ---------------------------------------------------------------------------------------- 

        internal MatrixFloat Adjugate()
        {
            if (this.NbLines == 2)
            {
                return new MatrixFloat(new MatrixFloat(new[,]
                {
                    { this[1, 1], -this[0, 1]},
                    { -this[1, 0], this[0, 0]}
                }));
            }

            MatrixFloat cofacMax = new MatrixFloat(this.NbLines, this.NbColumns);

            for (int i = 0; i < this.NbColumns; i++)
            {
                for (int e = 0; e < this.NbLines; e++)
                {
                    bool negate = (i % 2 == 0 && e % 2 == 0) || (i % 2 != 0 && e % 2 != 0);
                    cofacMax[i, e] = Determinant(this.SubMatrix(i, e)) * (negate ? 1 : -1);
                }
            }
            return cofacMax.Transpose();
        }

        internal static MatrixFloat Adjugate(MatrixFloat m) => m.Adjugate();

        // Exercice 15 ---------------------------------------------------------------------------------------- 

        internal MatrixFloat InvertByDeterminant()
        {
            float det = Determinant(this);
            if (det == 0) throw new MatrixInvertException();
            return Multiply(Adjugate(this), 1 / det);
        }

        internal static MatrixFloat InvertByDeterminant(MatrixFloat m) => m.InvertByDeterminant();

        [Serializable]
        internal class MatrixInvertException : Exception
        {
            public MatrixInvertException() { }
            public MatrixInvertException(string message) : base(message) { }
            public MatrixInvertException(string message, Exception innerException) : base(message, innerException) { }
            protected MatrixInvertException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }
}

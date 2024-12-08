using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUnitTestsHW
{
    public class MatrixInt
    {
        // Exercices 1 et 2 ----------------------------------------------------------------------------------------

        int[,] matrix;

        public MatrixInt (int numOfRows, int numOfCols) 
        {
            if (numOfRows <= 0 || numOfCols <= 0) { throw new Exception("Invalid parameters. Must be positive numbers."); }
            this.matrix = new int[numOfRows, numOfCols];
        }

        public MatrixInt(int[,] Array2D)
        {
            this.matrix = Array2D;
        }

        public MatrixInt(MatrixInt matrix) 
        {
            this.matrix = matrix.ToArray2D();
        }

        public int[,] ToArray2D()
        {
            //return matrix;
            return (int[,])matrix.Clone();
        }

        public int NbLines { get { return matrix.GetLength(0); } }
        public int NbColumns { get { return matrix.GetLength(1); } }

        public int this[int row, int col]
        {
            get => matrix[row, col]; 
            set => matrix[row, col] = value;
        }

        // Exercice 3 ----------------------------------------------------------------------------------------

        public static MatrixInt Identity(int size)
        {
            MatrixInt identityMax =  new MatrixInt(size, size);
            for (int i = 0; i < identityMax.NbLines; i++)
            {
                for (int e = 0; e < identityMax.NbColumns; e++)
                {
                    if (i == e) { identityMax[i, e] = 1; }
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
                    if (i == e && this[i, e] != 1) { return false; }
                    if (i != e && this[i, e] != 0) { return false; }
                }
            }
            return true;
        }

        // Exercice 4 ----------------------------------------------------------------------------------------

        public void Multiply (int factor)
        {
            for (int i = 0; i < NbLines; i++)
            {
                for (int e = 0; e < NbColumns; e++)
                {
                    this[i, e] *= factor;
                }
            }
        }
        
        public static MatrixInt Multiply (MatrixInt matrix, int factor)
        {
            MatrixInt productMatrix = new MatrixInt(matrix);
            productMatrix.Multiply(factor);
            return productMatrix;
        }

        public static MatrixInt operator *(MatrixInt matrix, int factor) => Multiply(matrix, factor);
        public static MatrixInt operator *(int factor, MatrixInt matrix) => Multiply(matrix, factor);

        public static MatrixInt operator -(MatrixInt matrix)
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

        // Exercice 5 ----------------------------------------------------------------------------------------
        
        public void Add(MatrixInt addendMatrix)
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

        public static MatrixInt Add(MatrixInt matrixA, MatrixInt matrixB)
        {
            MatrixInt sumMatrix = new MatrixInt(matrixA);
            sumMatrix.Add(matrixB);
            return sumMatrix;
        }

        public static MatrixInt operator +(MatrixInt matrixA, MatrixInt matrixB) => Add(matrixA, matrixB);

        public static MatrixInt operator -( MatrixInt matrixA, MatrixInt matrixB)
        {
            MatrixInt differenceMatrix = new MatrixInt(matrixA);
            for (int i = 0; i < differenceMatrix.NbLines; i++)
            {
                for (int e = 0; e < differenceMatrix.NbColumns; e++)
                {
                    differenceMatrix[i, e] -= matrixB[i, e];
                }
            }
            return differenceMatrix;
        }

        // Exercice 6 ----------------------------------------------------------------------------------------

        public MatrixInt Multiply(MatrixInt factorMatrix)
        {
            if (this.NbColumns != factorMatrix.NbLines) throw new MatrixMultiplyException();
            
            MatrixInt productMatrix = new MatrixInt(this.NbLines, factorMatrix.NbColumns);
            for (int i = 0; i< productMatrix.NbColumns; i++)
            {
                for (int e = 0;e < productMatrix.NbLines; e++) 
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

        public static MatrixInt Multiply(MatrixInt matrixA, MatrixInt matrixB)
        {
            MatrixInt productMatrix = new MatrixInt(matrixA.Multiply(matrixB));
            return matrixA.Multiply(matrixB);
        }

        public static MatrixInt operator *(MatrixInt matrixA, MatrixInt matrixB) => Multiply(matrixA, matrixB);

        // Exercice 7 ----------------------------------------------------------------------------------------

        public MatrixInt Transpose()
        {
            MatrixInt transMatrix = new MatrixInt(NbColumns, NbLines);
            for (int i = 0;i < NbColumns;i++)
            {
                for(int e = 0; e < NbLines; e++)
                {
                    transMatrix[i, e] = this[e, i];
                }
            }
            return transMatrix;
        }

        public static MatrixInt Transpose(MatrixInt matrix) =>  new MatrixInt(matrix.Transpose());

        // Exercice 9 ----------------------------------------------------------------------------------------
        
        public static MatrixInt GenerateAugmentedMatrix(MatrixInt transformationMatrix, MatrixInt smallerMatrix)
        {
            MatrixInt augMatrix = new MatrixInt(transformationMatrix.NbLines, transformationMatrix.NbColumns + 1);
            for (int i = 0; i < augMatrix.NbColumns; i++)
            {
                for (int e = 0; e < augMatrix.NbLines; e++)
                {
                    if (i == augMatrix.NbColumns-1) augMatrix[e, i] = smallerMatrix[e, 0];
                    else augMatrix[e, i] = transformationMatrix[e, i];
                }
            }
            return augMatrix;
        }

        public (MatrixInt, MatrixInt) Split(int colNum)
        {
            MatrixInt leftMax = new MatrixInt(NbLines, colNum+1);
            MatrixInt rightMax = new MatrixInt(NbLines, NbColumns-(colNum+1));

            for (int i = 0; i < NbColumns; i++)
            {
                for (int e = 0; e < NbLines; e++)
                {
                    //TestContext.WriteLine("{0}.{1}", i, e);
                    if (i <= colNum) leftMax[e, i] = this[e, i];
                    else rightMax[e, i-(colNum+1)] = this[e, i];
                }
            }
            return (leftMax, rightMax);
        }
    }

    [Serializable]
    internal class MatrixSumException : Exception
    {
        public MatrixSumException(){}
        public MatrixSumException(string message) : base(message){}
        public MatrixSumException(string message, Exception innerException) : base(message, innerException){}
        protected MatrixSumException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }    
    
    [Serializable]
    internal class MatrixMultiplyException : Exception
    {
        public MatrixMultiplyException(){}
        public MatrixMultiplyException(string message) : base(message){}
        public MatrixMultiplyException(string message, Exception innerException) : base(message, innerException){}
        protected MatrixMultiplyException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}

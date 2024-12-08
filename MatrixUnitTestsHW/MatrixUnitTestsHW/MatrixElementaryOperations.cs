using MatrixUnitTestsHW;
using System;
using System.Data.SqlTypes;
using System.Runtime.Serialization;

namespace Maths_Matrices.Tests
{    
    internal class MatrixElementaryOperations
    {
        public static void SwapLines(MatrixInt matrix, int rowA, int rowB)
        {
            int stroage;

            for (int i = 0; i < matrix.NbColumns; i++)
            {
                stroage = matrix[rowA, i];
                matrix[rowA, i] = matrix[rowB, i];
                matrix[rowB, i] = stroage;
            }
        }

        public static void SwapLinesF(MatrixFloat matrix, int rowA, int rowB)
        {
            float stroage;

            for (int i = 0; i < matrix.NbColumns; i++)
            {
                stroage = matrix[rowA, i];
                matrix[rowA, i] = matrix[rowB, i];
                matrix[rowB, i] = stroage;
            }
        }

        public static void SwapColumns(MatrixInt matrix, int colA, int colB)
        {
            int stroage;

            for (int i = 0; i < matrix.NbLines; i++)
            {
                stroage = matrix[i, colA];
                matrix[i, colA] = matrix[i, colB];
                matrix[i, colB] = stroage;
            }
        }

        public static void MultiplyLine(MatrixInt matrix, int lineNum, int factor)
        {
            if (factor == 0) throw new MatrixScalarZeroException();
            for (int i = 0; i < matrix.NbColumns; ++i)  matrix[lineNum, i] *= factor; 
        }
        
        public static void MultiplyLineF(MatrixFloat matrix, int lineNum, float factor)
        {
            if (factor == 0) throw new MatrixScalarZeroException();
            for (int i = 0; i < matrix.NbColumns; ++i)  matrix[lineNum, i] *= factor; 
        }
        
        public static void MultiplyColumn(MatrixInt matrix, int colNum, int factor)
        {
            if (factor == 0) throw new MatrixScalarZeroException();
            for (int i = 0; i < matrix.NbLines; ++i)  matrix[i, colNum] *= factor; 
        }

        public static void AddLineToAnother(MatrixInt matrix, int addendLineNum, int lineNum, int factor) 
        {
            for (int i = 0; i< matrix.NbColumns; ++i) matrix[lineNum, i] += matrix[addendLineNum, i] * factor;
        }
        
        public static void AddColumnToAnother(MatrixInt matrix, int addendColNum, int colNum, int factor) 
        {
            for (int i = 0; i< matrix.NbLines; ++i) matrix[i, colNum] += matrix[i, addendColNum] * factor;
        }
    }

    [Serializable]
    internal class MatrixScalarZeroException : Exception
    {
        public MatrixScalarZeroException() { }
        public MatrixScalarZeroException(string message) : base(message) { }
        public MatrixScalarZeroException(string message, Exception innerException) : base(message, innerException) { }
        protected MatrixScalarZeroException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
using MatrixUnitTestsHW;
using System;
using System.Numerics;

namespace Maths_Matrices.Tests
{

    public class Transform
    {
        // Exercices 17 ----------------------------------------------------------------------------------------

        public Transform() { }

        public Vector3 LocalPosition = new Vector3(0f, 0f, 0f);

        public MatrixFloat LocalTranslationMatrix
        {
            get { return GenerateLocalTranslationMatrix(); }
        }

        private MatrixFloat GenerateLocalTranslationMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 3] = LocalPosition.X;
            SolMat[1, 3] = LocalPosition.Y;
            SolMat[2, 3] = LocalPosition.Z;
            return SolMat;
        }


        // Exercices 18 ----------------------------------------------------------------------------------------

        public Vector3 LocalRotation = new Vector3(0f, 0f, 0f);

        public MatrixFloat LocalRotationMatrix
        {
            get { return GenerateLocalRotationXMatrix(); }
        }

        public MatrixFloat LocalRotationXMatrix
        {
            get { return GenerateLocalTranslationMatrix(); }
        }
        public MatrixFloat LocalRotationYMatrix
        {
            get { return GenerateLocalTranslationMatrix(); }
        }
        public MatrixFloat LocalRotationZMatrix
        {
            get { return GenerateLocalTranslationMatrix(); }
        }


        private MatrixFloat GenerateLocalRotationXMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[1, 1] = (float)Math.Cos(LocalRotation.X);
            SolMat[1, 2] = (float)Math.Sin(LocalRotation.X) *-1;
            SolMat[2, 1] = (float)Math.Sin(LocalRotation.X);
            SolMat[2, 2] = (float)Math.Cos(LocalRotation.X);
            return SolMat;
        }
    }
}
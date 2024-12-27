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
            get { return GenerateLocalRotationMatrix(); }
        }

        public MatrixFloat LocalRotationXMatrix
        {
            get { return GenerateLocalRotationXMatrix(); }
        }
        public MatrixFloat LocalRotationYMatrix
        {
            get { return GenerateLocalRotationYMatrix(); }
        }
        public MatrixFloat LocalRotationZMatrix
        {
            get { return GenerateLocalRotationZMatrix(); }
        }

        private MatrixFloat GenerateLocalRotationMatrix()
        {
            return GenerateLocalRotationYMatrix() * GenerateLocalRotationXMatrix() * GenerateLocalRotationZMatrix();
        }

        private MatrixFloat GenerateLocalRotationXMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[1, 1] = (float)Math.Cos(LocalRotation.X * Math.PI / 180);
            SolMat[1, 2] = (float)Math.Sin(LocalRotation.X * Math.PI / 180) *-1;
            SolMat[2, 1] = (float)Math.Sin(LocalRotation.X * Math.PI / 180);
            SolMat[2, 2] = (float)Math.Cos(LocalRotation.X * Math.PI / 180);
            return SolMat;
        }        
        
        private MatrixFloat GenerateLocalRotationYMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = (float)Math.Cos(LocalRotation.Y * Math.PI / 180);
            SolMat[0, 2] = (float)Math.Sin(LocalRotation.Y * Math.PI / 180);
            SolMat[2, 0] = (float)Math.Sin(LocalRotation.Y * Math.PI / 180) *-1;
            SolMat[2, 2] = (float)Math.Cos(LocalRotation.Y * Math.PI / 180);
            return SolMat;
        }        
        
        private MatrixFloat GenerateLocalRotationZMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = (float)Math.Cos(LocalRotation.Z * Math.PI / 180);
            SolMat[0, 1] = (float)Math.Sin(LocalRotation.Z * Math.PI / 180) *-1;
            SolMat[1, 0] = (float)Math.Sin(LocalRotation.Z * Math.PI / 180);
            SolMat[1, 1] = (float)Math.Cos(LocalRotation.Z * Math.PI / 180);
            return SolMat;
        }

        // Exercices 19 ----------------------------------------------------------------------------------------

        public Vector3 LocalScale = new Vector3(1f, 1f, 1f);

        public MatrixFloat LocalScaleMatrix { get { return GenerateLocalScaleMatrix(); } }

        private MatrixFloat GenerateLocalScaleMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = LocalScale.X;
            SolMat[1, 1] = LocalScale.Y;
            SolMat[2, 2] = LocalScale.Z;
            return SolMat;
        }
    }
}
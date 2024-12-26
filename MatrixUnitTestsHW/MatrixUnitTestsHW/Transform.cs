using MatrixUnitTestsHW;
using System;
using System.Numerics;

namespace Maths_Matrices.Tests
{
    // Exercices 17 ----------------------------------------------------------------------------------------

    public class Transform
    {
        public Transform() { }

        public Vector3 LocalPosition = new Vector3(0f,0f,0f);

        public MatrixFloat LocalTranslationMatrix { 
            get{ return GenerateLocalTranslationMatrix(); } 
        }

        private MatrixFloat GenerateLocalTranslationMatrix()
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 3] = LocalPosition.X;
            SolMat[1, 3] = LocalPosition.Y;
            SolMat[2, 3] = LocalPosition.Z;
            return SolMat;
            //testing
        }
    }
}
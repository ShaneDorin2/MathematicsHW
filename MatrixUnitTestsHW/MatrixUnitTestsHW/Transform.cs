﻿using MatrixUnitTestsHW;
using NUnit.Framework;
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
            get { return GenerateTranslationMatrix(LocalPosition); }
        }

        private MatrixFloat GenerateTranslationMatrix(Vector3 pos)
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 3] = pos.X;
            SolMat[1, 3] = pos.Y;
            SolMat[2, 3] = pos.Z;
            return SolMat;
        }


        // Exercices 18 ----------------------------------------------------------------------------------------

        public Vector3 LocalRotation = new Vector3(0f, 0f, 0f);

        public MatrixFloat LocalRotationMatrix
        {
            get { return GenerateRotationMatrix(LocalRotation); }
        }

        public MatrixFloat LocalRotationXMatrix
        {
            get { return GenerateRotationXMatrix(LocalRotation); }
        }
        public MatrixFloat LocalRotationYMatrix
        {
            get { return GenerateRotationYMatrix(LocalRotation); }
        }
        public MatrixFloat LocalRotationZMatrix
        {
            get { return GenerateRotationZMatrix(LocalRotation); }
        }

        private MatrixFloat GenerateRotationMatrix(Vector3 rot)
        {
            return GenerateRotationYMatrix(rot) * GenerateRotationXMatrix(rot) * GenerateRotationZMatrix(rot);
        }

        private MatrixFloat GenerateRotationXMatrix(Vector3 rot)
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[1, 1] = (float)Math.Cos(rot.X * Math.PI / 180);
            SolMat[1, 2] = (float)Math.Sin(rot.X * Math.PI / 180) *-1;
            SolMat[2, 1] = (float)Math.Sin(rot.X * Math.PI / 180);
            SolMat[2, 2] = (float)Math.Cos(rot.X * Math.PI / 180);
            return SolMat;
        }        
        
        private MatrixFloat GenerateRotationYMatrix(Vector3 rot)
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = (float)Math.Cos(rot.Y * Math.PI / 180);
            SolMat[0, 2] = (float)Math.Sin(rot.Y * Math.PI / 180);
            SolMat[2, 0] = (float)Math.Sin(rot.Y * Math.PI / 180) *-1;
            SolMat[2, 2] = (float)Math.Cos(rot.Y * Math.PI / 180);
            return SolMat;
        }        
        
        private MatrixFloat GenerateRotationZMatrix(Vector3 rot)
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = (float)Math.Cos(rot.Z * Math.PI / 180);
            SolMat[0, 1] = (float)Math.Sin(rot.Z * Math.PI / 180) *-1;
            SolMat[1, 0] = (float)Math.Sin(rot.Z * Math.PI / 180);
            SolMat[1, 1] = (float)Math.Cos(rot.Z * Math.PI / 180);
            return SolMat;
        }

        // Exercices 19 ----------------------------------------------------------------------------------------

        public Vector3 LocalScale = new Vector3(1f, 1f, 1f);

        public MatrixFloat LocalScaleMatrix { get { return GenerateScaleMatrix(LocalScale); } }

        private MatrixFloat GenerateScaleMatrix(Vector3 scale)
        {
            MatrixFloat SolMat = MatrixFloat.Identity(4);
            SolMat[0, 0] = scale.X;
            SolMat[1, 1] = scale.Y;
            SolMat[2, 2] = scale.Z;
            return SolMat;
        }

        // Exercices 20 ----------------------------------------------------------------------------------------

        public MatrixFloat LocalToWorldMatrix { get { return GenerateLocalToWorldMatrix(); } }
        public MatrixFloat WorldToLocalMatrix { get { return GenerateWorldToLocalMatrix(); } }

        private MatrixFloat GenerateLocalToWorldMatrix()
        {
            return GenerateTranslationMatrix(WorldPosition) * GenerateRotationMatrix(WorldRotation) * GenerateScaleMatrix(WorldScale);
        }

        private MatrixFloat GenerateWorldToLocalMatrix()
        {
            return (GenerateTranslationMatrix(LocalPosition) * GenerateRotationMatrix(LocalRotation) * GenerateScaleMatrix(LocalScale)).InvertByDeterminant();
        }

        // Exercices 21 ----------------------------------------------------------------------------------------

        private Transform Parent;
        public Vector3 WorldPosition { get 
            {
                if (Parent != null) 
                {
                    Vector3 solVec = LocalPosition * Parent.WorldScale;
                    return Parent.WorldPosition + Vector3.Transform(solVec, Quaternion.CreateFromYawPitchRoll(WorldRotation.Y, WorldRotation.X, WorldRotation.Z));
                    //return Parent.WorldPosition + Vector3.Transform(LocalPosition, Quaternion.CreateFromAxisAngle(Parent.WorldRotation, 0)); 
                }
                else return LocalPosition;
            } 
        }
        public Vector3 WorldRotation { get 
            {
                if (Parent != null)
                {
                    return Parent.WorldRotation + LocalRotation;
                }
                else return LocalRotation;
            } 
        }

        public Vector3 WorldScale { get
            {
                if (Parent != null)
                {
                    return Parent.WorldScale * LocalScale;
                }
                else return LocalScale;
            }
        }

        internal void SetParent(Transform tParent)
        {
            Parent = tParent;
        }
    }
}
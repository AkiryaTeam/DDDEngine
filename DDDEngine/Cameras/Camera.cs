using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Cameras
{
    public abstract class Camera
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double AngleX { get; set; }
        public double AngleY { get; set; }
        public double AngleZ { get; set; }
        public double NearZ { get; set; }
        public double FarZ { get; set; }

        protected Camera() { }

        protected Camera (double x, double y, double z, double angleX, double angleY, double angleZ, 
            double nearZ, double farZ)
        {
            X = x;
            Y = y;
            Z = z;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
            NearZ = nearZ;
            FarZ = farZ;
        }

        public abstract DenseMatrix GetProjectionMatrix();

        public DenseMatrix GetCameraMatrix()
        {
            var cameraTranslationMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, X},
                {0, 1, 0, Y},
                {0, 0, 1, Z},
                {0, 0, 0, 1}
            });
            var cameraRotationXMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, 0},
                {0, Math.Cos(DegreesToRadians(-AngleX)), -Math.Sin(DegreesToRadians(-AngleX)), 0},
                {0, Math.Sin(DegreesToRadians(-AngleX)), Math.Cos(DegreesToRadians(-AngleX)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationYMatrix = DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(DegreesToRadians(-AngleY)), 0, Math.Sin(DegreesToRadians(-AngleY)), 0},
                {0, 1, 0, 0},
                {-Math.Sin(DegreesToRadians(-AngleY)), 0, Math.Cos(DegreesToRadians(-AngleY)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationZMatrix = DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(DegreesToRadians(-AngleZ)), -Math.Sin(DegreesToRadians(-AngleZ)), 0, 0},
                {Math.Sin(DegreesToRadians(-AngleZ)), Math.Cos(DegreesToRadians(-AngleZ)), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            });
            var cameraMatrix = cameraTranslationMatrix*cameraRotationXMatrix*cameraRotationYMatrix*cameraRotationZMatrix;
            return cameraMatrix;
        }

        protected static double DegreesToRadians(double grad)
        {
            return grad*Math.PI/180;
        }
    }
}
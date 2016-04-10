using System;
using System.Windows.Controls;
using DDDEngine.Model;
using DDDEngine.Physics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.View
{
    public abstract class Camera: IObject
    {
        public double NearZ { get; set; }
        public double FarZ { get; set; }
        public Canvas Canvas { get; set; }

        protected Camera(Canvas canvas)
        {
            Canvas = canvas;
        }

        protected Camera (Canvas canvas, double nearZ, double farZ)
        {
            Canvas = canvas;
            NearZ = nearZ;
            FarZ = farZ;
        }

        public abstract DenseMatrix GetProjectionMatrix();

        public DenseMatrix GetCameraMatrix(Position position)
        {
            var cameraTranslationMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, position.Point.X},
                {0, 1, 0, position.Point.Y},
                {0, 0, 1, position.Point.Z},
                {0, 0, 0, 1}
            });
            var cameraRotationXMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, 0},
                {0, Math.Cos(DegreesToRadians(-position.AngleX)), -Math.Sin(DegreesToRadians(-position.AngleX)), 0},
                {0, Math.Sin(DegreesToRadians(-position.AngleX)), Math.Cos(DegreesToRadians(-position.AngleX)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationYMatrix = DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(DegreesToRadians(-position.AngleY)), 0, Math.Sin(DegreesToRadians(-position.AngleY)), 0},
                {0, 1, 0, 0},
                {-Math.Sin(DegreesToRadians(-position.AngleY)), 0, Math.Cos(DegreesToRadians(-position.AngleY)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationZMatrix = DenseMatrix.OfArray(new[,]
            {
                {Math.Cos(DegreesToRadians(-position.AngleZ)), -Math.Sin(DegreesToRadians(-position.AngleZ)), 0, 0},
                {Math.Sin(DegreesToRadians(-position.AngleZ)), Math.Cos(DegreesToRadians(-position.AngleZ)), 0, 0},
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

        public void Draw(Position position, RigidBody camera) { }

        public Viewport GetViewport()
        {
            return new Viewport(Canvas.ActualWidth, Canvas.ActualHeight);
        }
    }
}
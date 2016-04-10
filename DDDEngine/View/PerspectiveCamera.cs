using System;
using System.Windows.Controls;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.View
{
    public class PerspectiveCamera : Camera
    {
        public double FovX { get; set; }
        public double FovY { get; set; }

        public PerspectiveCamera(Canvas canvas) : this(canvas, 60, 60) { }

        public PerspectiveCamera(Canvas canvas, double fovX, double fovY) : base(canvas, 300, -300)
        {
            FovX = fovX;
            FovY = fovY;
        }

        public override DenseMatrix GetProjectionMatrix()
        {
            var viewport = GetViewport();
            var aspectRatio = viewport.Width/viewport.Height;
            var right = NearZ*Math.Tan(DegreesToRadians(FovX)/2);
            var top = right/aspectRatio;
            var projectionMatrix = DenseMatrix.OfArray(new[,]
            {
                {NearZ/right, 0, 0, 0},
                {0, NearZ/top, 0, 0},
                {0, 0, -(FarZ + NearZ)/(FarZ-NearZ), -(2*NearZ*FarZ)/(FarZ-NearZ)},
                {0, 0, -1, 0}
            });
            return projectionMatrix;
        }
    }
}
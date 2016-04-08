using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Cameras
{
    public class PerspectiveCamera : Camera
    {
        public double FovX { get; }
        public double FovY { get; }

        public PerspectiveCamera() : this(60, 60) { }

        public PerspectiveCamera(double fovX, double fovY) : base(0, 0, 1300, 0, 0, 0, 300, -300)
        {
            FovX = fovX;
            FovY = fovY;
        }

        public override DenseMatrix GetProjectionMatrix()
        {
            var viewport = new Viewport();
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
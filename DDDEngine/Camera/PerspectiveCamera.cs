using MathNet.Numerics.LinearAlgebra.Double;
using static System.Math;

namespace DDDEngine.Camera
{
    public class PerspectiveCamera : Camera
    {
        public double FovX { get; }
        public double FovY { get; }

        public PerspectiveCamera() : this(60, 30) { }

        public PerspectiveCamera(double fovX, double fovY)
        {
            FovX = fovX;
            FovY = fovY;
        }

        public override DenseMatrix GetProjectionMatrix()
        {
            var projectionMatrix = DenseMatrix.OfArray(new[,]
            {
                {1/Tan(GradToRad(FovX)/2), 0, 0, 0},
                {0, 1/Tan(GradToRad(FovY)/2), 0, 0},
                {0, 0, -((FarZ + NearZ)/(FarZ-NearZ)), -(2*(NearZ*FarZ)/(FarZ-NearZ))},
                {0, 0, -1, 0}
            });
            return projectionMatrix;
        }
    }
}
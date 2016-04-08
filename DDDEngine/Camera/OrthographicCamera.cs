using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Camera
{
    public class OrthographicCamera : Camera
    {
        public double Width { get; }
        public double Height { get; }

        public OrthographicCamera() : this(400, 300) { }

        public OrthographicCamera(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override DenseMatrix GetProjectionMatrix()
        {
            var projectionMatrix = DenseMatrix.OfArray(new[,]
            {
                {1/Width, 0, 0, 0},
                {0, 1/Height, 0, 0},
                {0, 0, -2/(FarZ-NearZ), -(FarZ+NearZ)/(FarZ-NearZ)},
                {0, 0, 0, 1}
            });
            return projectionMatrix;
        }
    }
}
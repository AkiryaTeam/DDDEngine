using DDDEngine.Configuration;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Cameras
{
    public class OrthographicCamera : Camera
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public OrthographicCamera() : this(Config.Canvas.ActualWidth, Config.Canvas.ActualHeight) { }

        public OrthographicCamera(double width, double height): base(0, 0, 0, 0, 0, 0, 300, -300)
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
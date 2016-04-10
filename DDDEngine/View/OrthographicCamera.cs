using System.Windows.Controls;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.View
{
    public class OrthographicCamera : Camera
    {
        public OrthographicCamera(Canvas canvas): base(canvas, 300, -300) { }

        public override DenseMatrix GetProjectionMatrix()
        {
            var viewport = GetViewport();
            var projectionMatrix = DenseMatrix.OfArray(new[,]
            {
                {1/viewport.Width, 0, 0, 0},
                {0, 1/viewport.Height, 0, 0},
                {0, 0, -2/(FarZ-NearZ), -(FarZ+NearZ)/(FarZ-NearZ)},
                {0, 0, 0, 1}
            });
            return projectionMatrix;
        }
    }
}
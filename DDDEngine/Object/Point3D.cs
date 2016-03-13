using System.Windows.Controls;
using System.Windows.Media;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Object
{
    public class Point3D: IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3D() { }

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Draw(Canvas canvas, Camera.Camera camera)
        {
                var point2D = ConvertTo2D(this, camera);
                var point = PointToWpfElement(point2D);
                canvas.Children.Add(point);
        }

        private Point2D ConvertTo2D(Point3D point3D, Camera.Camera camera)
        {
            var point2D = new Point2D();
            if (camera.CameraType == Camera.Camera.Type.Orthographic)
            {
                var projectionMatrix = DenseMatrix.OfArray(new double[,]
                {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                });
                var pointMatrix = DenseMatrix.OfArray(new double[,]
                {
                    {point3D.X},
                    {point3D.Y},
                    {point3D.Z}
                });
                var resultPointMatrix = projectionMatrix*pointMatrix;
                var values = resultPointMatrix.Values;
                point2D.X = (int) values[0];
                point2D.Y = (int) values[1];
            }
            else
            {
                point2D.X = point3D.X;
                point2D.Y = point3D.Y;
            }
            return point2D;
        }

        private System.Windows.Shapes.Shape PointToWpfElement(Point2D p) // TODO: convert to 3D
        {
            var element = new System.Windows.Shapes.Ellipse
            {
                Width = 1,
                Height = 1,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(element, p.X);
            Canvas.SetTop(element, p.Y);
            return element;
        }

    }
}
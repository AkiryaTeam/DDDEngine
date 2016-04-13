using System.Windows.Controls;
using System.Windows.Media;

namespace DDDEngine.Model
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public void Draw(Canvas canvas)
        {
            var point = PointToWpfElement();
            canvas.Children.Add(point);
        }

        private System.Windows.Shapes.Shape PointToWpfElement()
        {
            var element = new System.Windows.Shapes.Ellipse
            {
                Width = 1,
                Height = 1,
                Stroke = Brushes.Black,
                Fill = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(element, X);
            Canvas.SetTop(element, Y);
            return element;
        }

        public Point2D Substract(Point2D p)
        {
            return new Point2D
            {
                X = X-p.X,
                Y = Y-p.Y
            };
        }
    }
}
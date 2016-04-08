using System.Windows.Controls;
using System.Windows.Media;
using DDDEngine.Configuration;

namespace DDDEngine.Model
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public void Draw()
        {
            var point = PointToWpfElement();
            Config.Canvas.Children.Add(point);
        }

        private System.Windows.Shapes.Shape PointToWpfElement()
        {
            var element = new System.Windows.Shapes.Ellipse
            {
                Width = 1,
                Height = 1,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(element, X);
            Canvas.SetTop(element, Y);
            return element;
        }
    }
}
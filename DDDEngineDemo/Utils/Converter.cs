using System.Windows;
using System.Windows.Controls;
using DDDEngine.Model;

namespace DDDEngineDemo.Utils
{
    public class Converter
    {
        public static Point2D PositionToPoint2D(Canvas canvas, Point position)
        {
            return new Point2D {X = position.X-canvas.ActualWidth/2, Y = -(position.Y-canvas.ActualHeight/2)};
        }
    }
}
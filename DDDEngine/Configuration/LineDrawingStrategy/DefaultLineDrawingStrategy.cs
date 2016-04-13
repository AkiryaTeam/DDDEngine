using System.Windows.Controls;
using System.Windows.Media;
using DDDEngine.Model;

namespace DDDEngine.Configuration.LineDrawingStrategy
{
    public class DefaultLineDrawingStrategy : ILineDrawingStrategy
    {
        public void Draw(Canvas canvas, Point2D start, Point2D end)
        {
            var line = new System.Windows.Shapes.Line
            {
                X1 = start.X, Y1 = start.Y, 
                X2 = end.X, Y2 = end.Y,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            canvas.Children.Add(line);
        }
    }
}
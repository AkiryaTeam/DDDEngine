using Brushes = System.Windows.Media.Brushes;
using Shapes = System.Windows.Shapes;

namespace DDDEngine
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public static implicit operator Shapes.Line(Line l) // TODO: convert to 3D
        {
            var line = new Shapes.Line
            {
                X1 = l.Start.X,
                Y1 = l.Start.Y,
                X2 = l.End.X,
                Y2 = l.End.Y,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            return line;
        }
    }
}
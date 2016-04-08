using System.Windows.Controls;
using DDDEngine.Model.LineDrawingStrategy;

namespace DDDEngine.Model
{
    public class Line: IDrawable
    {
        private readonly ILineDrawingStrategy _strategy;
        public Point3D Start { get; set; }
        public Point3D End { get; set; }

        public Line(ILineDrawingStrategy strategy)
        {
            _strategy = strategy;
        }

        public Line(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Canvas canvas, Point3D worldPoint, Camera.Camera camera)
        {
            var start = Start.ConvertTo2D(worldPoint, camera, canvas);
            var end = End.ConvertTo2D(worldPoint, camera, canvas);
            _strategy.Draw(canvas, start, end);
        }

    }
}
using DDDEngine.Cameras;

namespace DDDEngine.Model
{
    public class Line: IDrawable
    {
        public Point3D Start { get; set; }
        public Point3D End { get; set; }

        public Line(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Point3D worldPoint, Camera camera)
        {
            var start = Start.ConvertTo2D(worldPoint, camera);
            var end = End.ConvertTo2D(worldPoint, camera);
            Configuration.Config.LineDrawingStrategy.Draw(start, end);
        }

    }
}
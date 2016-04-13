using DDDEngine.Model;

namespace DDDEngine.Utils
{
    public class LineFactory
    {
        public Line Create(Point3D start, Point3D end)
        {
            return new Line(start, end);
        }
    }
}
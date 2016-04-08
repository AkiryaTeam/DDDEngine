using DDDEngine.Model.LineDrawingStrategy;

namespace DDDEngine.Model
{
    public class LineFactory
    {
        private readonly ILineDrawingStrategy _strategy;

        public LineFactory(ILineDrawingStrategy strategy)
        {
            _strategy = strategy;
        }

        public Line Create(Point3D start, Point3D end)
        {
            return new Line(_strategy) {Start = start, End = end};
        }
    }
}
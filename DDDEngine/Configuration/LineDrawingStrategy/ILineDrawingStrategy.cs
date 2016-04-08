using DDDEngine.Model;

namespace DDDEngine.Configuration.LineDrawingStrategy
{
    public interface ILineDrawingStrategy
    {
        void Draw(Point2D start, Point2D end);
    }
}
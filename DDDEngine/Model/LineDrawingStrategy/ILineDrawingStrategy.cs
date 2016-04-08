using System.Windows.Controls;

namespace DDDEngine.Model.LineDrawingStrategy
{
    public interface ILineDrawingStrategy
    {
        void Draw(Canvas canvas, Point2D start, Point2D end);
    }
}
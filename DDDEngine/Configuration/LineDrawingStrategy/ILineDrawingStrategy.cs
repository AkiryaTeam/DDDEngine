using System.Windows.Controls;
using DDDEngine.Model;

namespace DDDEngine.Configuration.LineDrawingStrategy
{
    public interface ILineDrawingStrategy
    {
        void Draw(Canvas canvas, Point2D start, Point2D end);
    }
}
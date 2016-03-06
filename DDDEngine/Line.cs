using System.Windows.Controls;

namespace DDDEngine
{
    public class Line: IDrawable
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public void Draw(Canvas canvas, Camera camera) // TODO: implement bresenham
        {
            Start.Draw(canvas, camera);
            End.Draw(canvas, camera);
        }
    }
}
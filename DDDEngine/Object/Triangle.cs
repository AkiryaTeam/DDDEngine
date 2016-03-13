using System.Collections.Generic;
using System.Windows.Controls;

namespace DDDEngine.Object
{
    public class Triangle: IDrawable
    {
        readonly Point[] _points = new Point[3];

        public Triangle(IReadOnlyList<Point> points)
        {
            for (var i = 0; i < _points.Length; i++)
            {
                _points[i] = points[i];
            }
        }

        public void Draw(Canvas canvas, Camera.Camera camera)
        {
            var lines = new Line[3];
            lines[0] = new Line(_points[0], _points[1]);
            lines[1] = new Line(_points[1], _points[2]);
            lines[2] = new Line(_points[2], _points[0]);
            foreach (var line in lines)
            {
                line.Draw(canvas, camera);
            }
        }
    }
}
using System.Collections.Generic;
using System.Windows.Controls;

namespace DDDEngine.Model
{
    public class Triangle: IDrawable
    {
        readonly Point3D[] _points = new Point3D[3];

        public Triangle(IReadOnlyList<Point3D> points)
        {
            for (var i = 0; i < _points.Length; i++)
            {
                _points[i] = points[i];
            }
        }

        public void Draw(Canvas canvas, Point3D worldPoint, Camera.Camera camera)
        {
            var lines = new Line[3];
            lines[0] = new Line(_points[0], _points[1]);
            lines[1] = new Line(_points[1], _points[2]);
            lines[2] = new Line(_points[2], _points[0]);
            foreach (var line in lines)
            {
                line.Draw(canvas, worldPoint, camera);
            }
        }
    }
}
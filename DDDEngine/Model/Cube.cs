using System.Collections.Generic;
using DDDEngine.Utils;

namespace DDDEngine.Model
{
    public class Cube: IDrawable
    {
        private readonly List<Line> _lines = new List<Line>(12); 
        public double Width { get; set; }

        public Cube(): this(50) { }

        public Cube(double width)
        {
            Width = width;
            CreateLines();
        }

        private void CreateLines()
        {
            var ps = CreatePoints();
            var lineFactory = new LineFactory();
            _lines.Add(lineFactory.Create(ps[0], ps[1]));
            _lines.Add(lineFactory.Create(ps[1], ps[2]));
            _lines.Add(lineFactory.Create(ps[2], ps[3]));
            _lines.Add(lineFactory.Create(ps[3], ps[0]));
            _lines.Add(lineFactory.Create(ps[4], ps[5]));
            _lines.Add(lineFactory.Create(ps[5], ps[6]));
            _lines.Add(lineFactory.Create(ps[6], ps[7]));
            _lines.Add(lineFactory.Create(ps[7], ps[4]));
            _lines.Add(lineFactory.Create(ps[0], ps[4]));
            _lines.Add(lineFactory.Create(ps[1], ps[5]));
            _lines.Add(lineFactory.Create(ps[2], ps[6]));
            _lines.Add(lineFactory.Create(ps[3], ps[7]));
        }

        private List<Point3D> CreatePoints()
        {
            var half = Width/2;
            var ps = new List<Point3D>
            {
                new Point3D(-half, -half, -half),
                new Point3D(half, -half, -half),
                new Point3D(half, -half, half),
                new Point3D(-half, -half, half),
                new Point3D(-half, half, -half),
                new Point3D(half, half, -half),
                new Point3D(half, half, half),
                new Point3D(-half, half, half)
            };
            return ps;
        }

        public void Draw(Point3D worldPoint, Cameras.Camera camera)
        {
            _lines.ForEach(l => l.Draw(worldPoint, camera));
        }
    }
}
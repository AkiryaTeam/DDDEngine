using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;

namespace DDDEngine.Model
{
    public class Parallelepiped: IObject
    {
        private readonly List<Line> _lines = new List<Line>(12); 
        public double Width { get; set; }
        public double Heigth { get; set; }
        public double Depth { get; set; }

        public Parallelepiped() : this(200, 100, 200) { }

        public Parallelepiped(double width, double heigth, double depth)
        {
            Width = width;
            Heigth = heigth;
            Depth = depth;
            CreateLines();
        }

        protected void CreateLines()
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

        protected List<Point3D> CreatePoints()
        {
            var halfWidth = Width / 2;
            var halfHeigth = Heigth / 2;
            var halfDepth = Depth / 2;
            var ps = new List<Point3D>
            {
                new Point3D(-halfWidth, -halfHeigth, -halfDepth),
                new Point3D(halfWidth, -halfHeigth, -halfDepth),
                new Point3D(halfWidth, -halfHeigth, halfDepth),
                new Point3D(-halfWidth, -halfHeigth, halfDepth),
                new Point3D(-halfWidth, halfHeigth, -halfDepth),
                new Point3D(halfWidth, halfHeigth, -halfDepth),
                new Point3D(halfWidth, halfHeigth, halfDepth),
                new Point3D(-halfWidth, halfHeigth, halfDepth)
            };
            return ps;
        }

        public void Draw(Position position, RigidBody camera)
        {
            _lines.ForEach(l => l.Draw(position, camera));
        }
    }
}

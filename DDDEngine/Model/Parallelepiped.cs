using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;

namespace DDDEngine.Model
{
    public class Parallelepiped: IObject
    {
        private readonly List<Line> _lines = new List<Line>(12); 
        private List<Point3D> _points;
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
            _points = CreatePoints();
            var lineFactory = new LineFactory();
            _lines.Add(lineFactory.Create(_points[0], _points[1]));
            _lines.Add(lineFactory.Create(_points[1], _points[2]));
            _lines.Add(lineFactory.Create(_points[2], _points[3]));
            _lines.Add(lineFactory.Create(_points[3], _points[0]));
            _lines.Add(lineFactory.Create(_points[4], _points[5]));
            _lines.Add(lineFactory.Create(_points[5], _points[6]));
            _lines.Add(lineFactory.Create(_points[6], _points[7]));
            _lines.Add(lineFactory.Create(_points[7], _points[4]));
            _lines.Add(lineFactory.Create(_points[0], _points[4]));
            _lines.Add(lineFactory.Create(_points[1], _points[5]));
            _lines.Add(lineFactory.Create(_points[2], _points[6]));
            _lines.Add(lineFactory.Create(_points[3], _points[7]));
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

        public BoundingBox GetBoundingBox(Position position)
        {
            var center = new Point3D(position.Point);
            var halfWidth = new Point3D(_points[6]);
            return new BoundingBox(center, halfWidth);
        }
    }
}

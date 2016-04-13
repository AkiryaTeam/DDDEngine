using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;

namespace DDDEngine.Model
{
    public class Plane: IObject
    {
        private readonly List<Line> _lines = new List<Line>(4);
        private List<Point3D> _points;
        public double Width { get; set; }
        public double Depth { get; set; }

        public Plane(): this(400, 400) { }

        public Plane(double width, double depth)
        {
            Width = width;
            Depth = depth;
            CreateLines();
        }

        private void CreateLines()
        {
            _points = CreatePoints();
            var lineFactory = new LineFactory();
            _lines.Add(lineFactory.Create(_points[0], _points[1]));
            _lines.Add(lineFactory.Create(_points[1], _points[2]));
            _lines.Add(lineFactory.Create(_points[2], _points[3]));
            _lines.Add(lineFactory.Create(_points[3], _points[0]));
        }

        private List<Point3D> CreatePoints()
        {
            var halfX = Width/2;
            var halfZ = Depth/2;
            var ps = new List<Point3D>
            {
                new Point3D(-halfX, 0, -halfZ),
                new Point3D(halfX, 0, -halfZ),
                new Point3D(halfX, 0, halfZ),
                new Point3D(-halfX, 0, halfZ),
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
            var halfWidth = new Point3D(_points[2]);
            return new BoundingBox(center, halfWidth);
        }
    }
}
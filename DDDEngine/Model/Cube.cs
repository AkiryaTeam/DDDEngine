using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;

namespace DDDEngine.Model
{
    public class Cube: IObject
    {
        protected readonly List<Line> Lines = new List<Line>(12);
        private List<Point3D> _points;
        public double Width { get; set; }

        public Cube(): this(50) { }

        public Cube(double width)
        {
            Width = width;
            CreateLines();
        }

        protected void CreateLines()
        {
            _points = CreatePoints();
            var lineFactory = new LineFactory();
            Lines.Add(lineFactory.Create(_points[0], _points[1]));
            Lines.Add(lineFactory.Create(_points[1], _points[2]));
            Lines.Add(lineFactory.Create(_points[2], _points[3]));
            Lines.Add(lineFactory.Create(_points[3], _points[0]));
            Lines.Add(lineFactory.Create(_points[4], _points[5]));
            Lines.Add(lineFactory.Create(_points[5], _points[6]));
            Lines.Add(lineFactory.Create(_points[6], _points[7]));
            Lines.Add(lineFactory.Create(_points[7], _points[4]));
            Lines.Add(lineFactory.Create(_points[0], _points[4]));
            Lines.Add(lineFactory.Create(_points[1], _points[5]));
            Lines.Add(lineFactory.Create(_points[2], _points[6]));
            Lines.Add(lineFactory.Create(_points[3], _points[7]));
        }

        protected List<Point3D> CreatePoints()
        {
            var half = Width/2; // TODO: remove hack
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

        public void Draw(Position position, RigidBody camera)
        {
            Lines.ForEach(l => l.Draw(position, camera));
        }

        public Box GetBoundingBox(Position position)
        {
            var center = new Point3D(position.Point);
            var halfWidth = new Point3D(_points[6]);
            return new Box(center, halfWidth);
        }
    }
}
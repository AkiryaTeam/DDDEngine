using System.Collections.Generic;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.Utils;
using static System.Math;

namespace DDDEngineDemo.ModelsDemo
{
    public class CustomModel: IObject
    {
        private readonly List<Line> _lines = new List<Line>(12);
        private List<Point3D> _points; 

        public CustomModel()
        {
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
            var ps = new List<Point3D>
            {
                new Point3D(-100, -50, -150),
                new Point3D(100, -50, -150),
                new Point3D(100, -50, 150),
                new Point3D(-100, -50, 150),

                new Point3D(-100, 50, -150),
                new Point3D(100, 50, -150),
                new Point3D(200, 150, 300),
                new Point3D(-200, 150, 300)
            };
            return ps;
        }

        public void Draw(Position position, RigidBody camera)
        {
            _lines.ForEach(l => l.Draw(position, camera));
        }

        public BoundingBox GetBoundingBox(Position position)
        {
            var centerBetween = _points[0].ComputeCenter(_points[6]);
            var center = new Point3D
            {
                X = Abs(centerBetween.X) + position.Point.X,
                Y = Abs(centerBetween.Y) + position.Point.Y,
                Z = Abs(centerBetween.Z) + position.Point.Z
            };
            var halfWidth = new Point3D(_points[6]);
            return new BoundingBox(center, halfWidth);
        }
    }
}

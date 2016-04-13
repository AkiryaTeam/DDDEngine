using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;
using static System.Math;

namespace DDDEngine.Model
{
    public class Tetrahedron: IObject
    {
        private readonly List<Line> _lines = new List<Line>(6);
        private double _halfHeigth;
        private double _halfHeigthOfBase;
        private double _halfEdgeLength;
        private List<Point3D> _points;
        public double EdgeLength { get; set; }
        public double Heigth { get; set; }

        public Tetrahedron() : this(100) { }

        public Tetrahedron(double edgeLength)
        {
            EdgeLength = edgeLength;
            Heigth = Sqrt(2) / Sqrt( 3) * EdgeLength;
            CreateLines();
        }

        protected void CreateLines()
        {
            _points = CreatePoints();
            var lineFactory = new LineFactory();
            _lines.Add(lineFactory.Create(_points[0], _points[1]));
            _lines.Add(lineFactory.Create(_points[1], _points[2]));
            _lines.Add(lineFactory.Create(_points[2], _points[0]));
            _lines.Add(lineFactory.Create(_points[0], _points[3]));
            _lines.Add(lineFactory.Create(_points[1], _points[3]));
            _lines.Add(lineFactory.Create(_points[2], _points[3]));
        }

        protected List<Point3D> CreatePoints()
        {
            _halfEdgeLength = EdgeLength / 2;
            _halfHeigth = Heigth / 2;
            _halfHeigthOfBase = Sqrt(3) / 2 * EdgeLength / 2;
            var ps = new List<Point3D>
            {
                new Point3D(0, -_halfHeigth, -_halfHeigthOfBase),
                new Point3D(_halfEdgeLength, -_halfHeigth, _halfHeigthOfBase),
                new Point3D(-_halfEdgeLength, -_halfHeigth, _halfHeigthOfBase),
                new Point3D(0, _halfHeigth, 0),
            };
            return ps;
        }

        public void Draw(Position position, RigidBody camera)
        {
            _lines.ForEach(l => l.Draw(position, camera));
        }

        public BoundingBox GetBoundingBox(Position position)
        {
            var center = new Point3D
            {
                X = _halfEdgeLength + position.Point.X,
                Y = _halfHeigth + position.Point.Y,
                Z = _halfHeigthOfBase + position.Point.Z
            };
            var halfWidth = new Point3D
            {
                X = Abs(_points[2].X),
                Y = Abs(_points[2].Y),
                Z = Abs(_points[2].Z)
            };
            return new BoundingBox(center, halfWidth);
        }
    }
}

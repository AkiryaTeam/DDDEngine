using System.Collections.Generic;
using DDDEngine.Physics;
using DDDEngine.Utils;
using System;

namespace DDDEngine.Model
{
    public class Tetrahedron: IObject
    {
        private readonly List<Line> _lines = new List<Line>(6); 
        public double EdgeLength { get; set; }
        public double Heigth { get; set; }

        public Tetrahedron() : this(100) { }

        public Tetrahedron(double edgeLength)
        {
            EdgeLength = edgeLength;
            Heigth = Math.Sqrt(2) / Math.Sqrt( 3) * EdgeLength;
            CreateLines();
        }

        protected void CreateLines()
        {
            var ps = CreatePoints();
            var lineFactory = new LineFactory();
            _lines.Add(lineFactory.Create(ps[0], ps[1]));
            _lines.Add(lineFactory.Create(ps[1], ps[2]));
            _lines.Add(lineFactory.Create(ps[2], ps[0]));
            _lines.Add(lineFactory.Create(ps[0], ps[3]));
            _lines.Add(lineFactory.Create(ps[1], ps[3]));
            _lines.Add(lineFactory.Create(ps[2], ps[3]));
        }

        protected List<Point3D> CreatePoints()
        {
            var halfEdgeLength = EdgeLength / 2;
            var halfHeigth = Heigth / 2;
            var halfHeigthOfBase = Math.Sqrt(3) / 2 * EdgeLength / 2;
            var ps = new List<Point3D>
            {
                new Point3D(0, -halfHeigth, -halfHeigthOfBase),
                new Point3D(halfEdgeLength, -halfHeigth, halfHeigthOfBase),
                new Point3D(-halfEdgeLength, -halfHeigth, halfHeigthOfBase),
                new Point3D(0, halfHeigth, 0),
            };
            return ps;
        }

        public void Draw(Position position, RigidBody camera)
        {
            _lines.ForEach(l => l.Draw(position, camera));
        }
    }
}

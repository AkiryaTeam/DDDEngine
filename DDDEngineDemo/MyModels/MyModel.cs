﻿using DDDEngine.Model;
using DDDEngine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDEngineDemo
{
    public class MyModel:IObject
    {
        public MyModel()
        {
            _lines = new List<Line>(12);
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
    }
}

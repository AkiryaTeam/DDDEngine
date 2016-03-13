using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DDDEngine.Object
{
    public class Line: IDrawable
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line() { }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Canvas canvas, Camera.Camera camera)
        {
            var points = ComputeLInePoints();
            foreach (var point in points)
            {
                point.Draw(canvas, camera);
            }
        }

        private IEnumerable<Point> ComputeLInePoints()
        {
            var points = new List<Point>();
            var deltaX = Math.Abs(End.X - Start.X);
            var deltaY = Math.Abs(End.Y - Start.Y);
            var signX = Start.X < End.X ? 1 : -1;
            var signY = Start.Y < End.Y ? 1 : -1;
            var error = deltaX - deltaY;

            while (Start.X != End.X || Start.Y != End.Y)
            {
                points.Add(new Point { X = Start.X, Y = Start.Y });
                var error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    Start.X += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    Start.Y += signY;
                }
            }
            points.Add(End);
            return points;
        }
    }
}
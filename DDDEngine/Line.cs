using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DDDEngine
{
    public class Line: IDrawable
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public void Draw(Canvas canvas, Camera camera) // TODO: implement bresenham
        {
            List<Point> points = LineToWpfElement();
            foreach (var point in points)
            {
                point.Draw(canvas, camera);
            }
        }
        private List<Point> LineToWpfElement()
        {
            List<Point> points = new List<Point>();
            int deltaX = Math.Abs(End.X - Start.X);
            int deltaY = Math.Abs(End.Y - Start.Y);
            int signX = Start.X < End.X ? 1 : -1;
            int signY = Start.Y < End.Y ? 1 : -1;
            int error = deltaX - deltaY;

            while (Start.X != End.X || Start.Y != End.Y)
            {
                points.Add(new Point { X = Start.X, Y = Start.Y });
                int error2 = error * 2;
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
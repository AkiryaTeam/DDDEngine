using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DDDEngine.Model.LineDrawingStrategy
{
    public class BresenhamLineDrawingStrategy : ILineDrawingStrategy
    {
        public void Draw(Canvas canvas, Point2D start, Point2D end)
        {
            var points = ComputeLinePoints(start, end);
            foreach (var point in points)
            {
                point.Draw(canvas);
            }
        }

        private IEnumerable<Point2D> ComputeLinePoints(Point2D start, Point2D end)
        {
            var points = new List<Point2D>();
            var startX = start.X;
            var startY = start.Y;
            var endX = end.X;
            var endY = end.Y;
            var deltaX = Math.Abs(endX - startX);
            var deltaY = Math.Abs(endY - startY);
            var signX = startX < endX ? 1 : -1;
            var signY = startY < endY ? 1 : -1;
            var error = deltaX - deltaY;

            while ((Math.Abs(startX - endX) > 0.001 || Math.Abs(startY - endY) > 0.001) && 
                   signX == (startX < endX ? 1 : -1) && signY == (startY < endY ? 1 : -1))
            {
                points.Add(new Point2D { X = startX, Y = startY });
                var error2 = error * 2;
                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    startX += signX;
                }
                if (error2 < deltaX)
                {
                    error += deltaX;
                    startY += signY;
                }
            }
            points.Add(end);
            return points;
        }
    }
}
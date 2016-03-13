﻿using System.Windows.Controls;
using System.Windows.Media;

namespace DDDEngine.Object
{
    public class Point: IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public void Draw(Canvas canvas, Camera.Camera camera)
        {
            var point = PointToWpfElement(this);
            canvas.Children.Add(point);
        }

        private System.Windows.Shapes.Shape PointToWpfElement(Point p) // TODO: convert to 3D
        {
            var element = new System.Windows.Shapes.Ellipse
            {
                Width = 1,
                Height = 1,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(element, p.X);
            Canvas.SetTop(element, p.Y);
            return element;
        }

    }
}
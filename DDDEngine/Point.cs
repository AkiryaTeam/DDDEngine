namespace DDDEngine
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static implicit operator System.Windows.Point(Point p) // TODO: convert to 3D
        {
            var point2D = new System.Windows.Point();
            point2D.X = p.X;
            point2D.Y = p.Y;
            return point2D;
        }

        public static implicit operator System.Drawing.Point(Point p) // TODO: convert to 3D
        {
            var point2D = new System.Drawing.Point();
            point2D.X = p.X;
            point2D.Y = p.Y;
            return point2D;
        }
    }
}
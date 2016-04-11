namespace DDDEngine.Model
{
    public class Box
    {
        public Point3D Center { get; set; }
        public Point3D HalfWidth { get; set; }

        public Box(Point3D center, Point3D halfWidth)
        {
            Center = center;
            HalfWidth = halfWidth;
        }

        public Box() { }
    }
}
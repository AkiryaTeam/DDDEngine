namespace DDDEngine.Model
{
    public class BoundingBox
    {
        public Point3D Center { get; set; }
        public Point3D HalfWidth { get; set; }

        public BoundingBox(Point3D center, Point3D halfWidth)
        {
            Center = center;
            HalfWidth = halfWidth;
        }

        public BoundingBox() { }
    }
}
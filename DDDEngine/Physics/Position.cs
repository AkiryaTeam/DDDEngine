using DDDEngine.Model;

namespace DDDEngine.Physics
{
    public class Position
    {
        public Point3D Point { get; set; } = new Point3D();
        public double AngleX { get; set; }
        public double AngleY { get; set; }
        public double AngleZ { get; set; }

        public Position() { }

        public Position(Point3D point, double angleX, double angleY, double angleZ)
        {
            Point = point;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
        }

        public Position(double angleX, double angleY, double angleZ)
        {
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
        }
    }
}
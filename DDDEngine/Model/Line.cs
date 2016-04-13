using DDDEngine.Physics;
using DDDEngine.View;
using static System.Math;

namespace DDDEngine.Model
{
    public class Line: IObject
    {
        public Point3D Start { get; set; }
        public Point3D End { get; set; }

        public Line(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }

        public void Draw(Position position, RigidBody cameraBody)
        {
            var camera = (Camera) cameraBody.Object;
            var start = Start.ConvertTo2D(position, camera, cameraBody.Position);
            var end = End.ConvertTo2D(position, camera, cameraBody.Position);
            Configuration.Config.LineDrawingStrategy.Draw(camera.Canvas, start, end);
        }

        public BoundingBox GetBoundingBox(Position position)
        {
            var center = Start.ComputeCenter(End);
            center.X += position.Point.X;
            center.Y += position.Point.Y;
            center.Y += position.Point.Z;
            var halfWidth = new Point3D(Abs(End.X), Abs(End.Y), Abs(End.Z));
            return new BoundingBox(center, halfWidth);
        }
    }
}
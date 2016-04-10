using DDDEngine.Physics;
using DDDEngine.View;

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

    }
}
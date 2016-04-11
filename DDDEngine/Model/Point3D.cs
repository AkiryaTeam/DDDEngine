using DDDEngine.Physics;
using DDDEngine.View;
using MathNet.Numerics.LinearAlgebra.Double;

namespace DDDEngine.Model
{
    public class Point3D: IObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D() { }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Point3D p)
        {
            X = p.X;
            Y = p.Y;
            Z = p.Z;
        }

        public void Draw(Position position, RigidBody cameraBody)
        {
            var camera = (Camera) cameraBody.Object;
            var point2D = ConvertTo2D(position, camera, cameraBody.Position);
            point2D.Draw(camera.Canvas);
        }

        public Point2D ConvertTo2D(Position pointPosition,  Camera camera, Position cameraPosition)
        {
            var point2D = new Point2D();
            var worldMatrix = GetWorldMatrix(pointPosition);
            var cameraMatrix = camera.GetCameraMatrix(cameraPosition);
            var projectionMatrix = camera.GetProjectionMatrix();
            var transformMatrix = projectionMatrix*cameraMatrix*worldMatrix;
            var pointMatrix = DenseMatrix.OfArray(new[,]
            {
                {X},
                {Y},
                {Z},
                {1}
            });

            var resultPointMatrix = transformMatrix*pointMatrix;
            var values = resultPointMatrix.Values;
            if (camera is PerspectiveCamera)
            {
                resultPointMatrix = 1/values[3]*resultPointMatrix;
                values = resultPointMatrix.Values;
            }

            var viewport = camera.GetViewport();
            point2D.X = (values[0] + 1)*viewport.Width/2 + viewport.X;
            point2D.Y = (values[1] + 1)*viewport.Height/2 + viewport.Y;
            return point2D;
        }

        private DenseMatrix GetWorldMatrix(Position position)
        {
            return DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, position.Point.X},
                {0, 1, 0, position.Point.Y},
                {0, 0, 1, -position.Point.Z},
                {0, 0, 0, 1}
            });
        }

        public Box GetBoundingBox(Position position)
        {
            var center = Add(position.Point);
            var halfWidth = new Point3D(0.5, 0.5, 0.5);
            return new Box(center, halfWidth);
        }

        public Point3D Add(Point3D p)
        {
            return new Point3D
            {
                X = p.X + X,
                Y = p.Y + Y,
                Z = p.Z + Z
            };
        }

    }
}
using MathNet.Numerics.LinearAlgebra.Double;
using static System.Math;

namespace DDDEngine.Camera
{
    public abstract class Camera
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double AngleX { get; set; }
        public double AngleY { get; set; }
        public double AngleZ { get; set; }
        public double NearZ { get; }
        public double FarZ { get; }

        protected Camera() : this(0, 0, 0, 0, 0, 0, 300, -300) { }

        protected Camera (double x, double y, double z, double angleX, double angleY, double angleZ, 
            double nearZ, double farZ)
        {
            X = x;
            Y = y;
            Z = z;
            AngleX = angleX;
            AngleY = angleY;
            AngleZ = angleZ;
            NearZ = nearZ;
            FarZ = farZ;
        }

        public abstract DenseMatrix GetProjectionMatrix();

        public DenseMatrix GetCameraMatrix()
        {
            var cameraTranslationMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, X},
                {0, 1, 0, Y},
                {0, 0, 1, Z},
                {0, 0, 0, 1}
            });
            var cameraRotationXMatrix = DenseMatrix.OfArray(new[,]
            {
                {1, 0, 0, 0},
                {0, Cos(GradToRad(-AngleX)), -Sin(GradToRad(-AngleX)), 0},
                {0, Sin(GradToRad(-AngleX)), Cos(GradToRad(-AngleX)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationYMatrix = DenseMatrix.OfArray(new[,]
            {
                {Cos(GradToRad(-AngleY)), 0, Sin(GradToRad(-AngleY)), 0},
                {0, 1, 0, 0},
                {-Sin(GradToRad(-AngleY)), 0, Cos(GradToRad(-AngleY)), 0},
                {0, 0, 0, 1}
            });
            var cameraRotationZMatrix = DenseMatrix.OfArray(new[,]
            {
                {Cos(GradToRad(-AngleZ)), -Sin(GradToRad(-AngleZ)), 0, 0},
                {Sin(GradToRad(-AngleZ)), Cos(GradToRad(-AngleZ)), 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            });
            var cameraMatrix = cameraTranslationMatrix*cameraRotationXMatrix*cameraRotationYMatrix*cameraRotationZMatrix;
            return cameraMatrix;
        }

        protected static double GradToRad(double grad)
        {
            return grad*PI/180;
        }
    }
}
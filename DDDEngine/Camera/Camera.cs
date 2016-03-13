namespace DDDEngine.Camera
{
    public class Camera
    {
        public enum Type
        {
            Orthographic, Perspective
        }
        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }
        private int AngleX { get; set; }
        private int AngleY { get; set; }
        private int AngleZ { get; set; }
        public Type CameraType { get; }

        public Camera (Type type)
        {
            CameraType = type;
        }
    }
}
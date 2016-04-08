using DDDEngine.Configuration;

namespace DDDEngine.Cameras
{
    public class Viewport
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Viewport()
        {
            Width = Config.Canvas.ActualWidth;
            Height = Config.Canvas.ActualHeight;
            X = 0;
            Y = 0;
            Z = 0;
        }
    }
}
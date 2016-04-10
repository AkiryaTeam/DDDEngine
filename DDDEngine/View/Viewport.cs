namespace DDDEngine.View
{
    public class Viewport
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Viewport(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
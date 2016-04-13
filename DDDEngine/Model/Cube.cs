namespace DDDEngine.Model
{
    public class Cube: Parallelepiped
    {
        public Cube() : base(100, 100, 100) { }
        public Cube(double size) : base(size, size, size) { }
        public Cube(double width, double heigth, double depth):base(width, heigth, depth) { }
    }
}
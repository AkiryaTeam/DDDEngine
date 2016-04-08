namespace DDDEngine.Model
{
    public interface IDrawable
    {
        void Draw(Point3D worldPoint, Cameras.Camera camera);
    }
}
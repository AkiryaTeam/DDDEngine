using System.Windows.Controls;

namespace DDDEngine.Model
{
    public interface IDrawable
    {
        void Draw(Canvas canvas, Point3D worldPoint, Camera.Camera camera);
    }
}
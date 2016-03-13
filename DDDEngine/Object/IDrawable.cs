using System.Windows.Controls;

namespace DDDEngine.Object
{
    public interface IDrawable
    {
        void Draw(Canvas canvas, Camera.Camera camera);
    }
}
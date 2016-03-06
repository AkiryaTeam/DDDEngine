using System.Windows;
using System.Windows.Controls;

namespace DDDEngine
{
    public interface IDrawable
    {
        void Draw(Canvas canvas, Camera camera);
    }
}
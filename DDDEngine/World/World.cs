using System.Collections.Generic;
using System.Windows.Controls;
using DDDEngine.Model;

namespace DDDEngine.World
{
    public class World
    {
        private readonly Dictionary<IDrawable, Point3D> _objects;
        private readonly Camera.Camera _camera;

        public World(Camera.Camera camera)
        {
            _objects = new Dictionary<IDrawable, Point3D>();
            _camera = camera;
        }

        public void AddObject(IDrawable obj, Point3D point)
        {
            _objects.Add(obj, point);
        }

        public void Draw(Canvas canvas)
        {
            canvas.Children.Clear();
            foreach (var obj in _objects)
            {
                obj.Key.Draw(canvas, obj.Value, _camera);
            }
        }

    }
}
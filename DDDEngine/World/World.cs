using System.Collections.Generic;
using System.Windows.Controls;
using DDDEngine.Object;

namespace DDDEngine.World
{
    public class World
    {
        private readonly List<IDrawable> _objects;
        private readonly Camera.Camera _camera;

        public World(Camera.Camera camera)
        {
            _objects = new List<IDrawable>();
            _camera = camera;
        }

        public void AddObject(IDrawable obj)
        {
            _objects.Add(obj);
        }

        public void Draw(Canvas canvas)
        {
            foreach (var obj in _objects)
            {
                obj.Draw(canvas, _camera);
            }
        }
    }
}
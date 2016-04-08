using System.Collections.Generic;
using DDDEngine.Cameras;
using DDDEngine.Configuration;
using DDDEngine.Model;

namespace DDDEngine.World
{
    public class World3D
    {
        private readonly Dictionary<IDrawable, Point3D> _objects;
        public Camera Camera { get; }

        public World3D(Camera camera)
        {
            _objects = new Dictionary<IDrawable, Point3D>();
            Camera = camera;
        }

        public void AddObject(IDrawable obj, Point3D point)
        {
            _objects.Add(obj, point);
        }

        public void Draw()
        {
            Config.Canvas.Children.Clear();
            foreach (var obj in _objects)
            {
                obj.Key.Draw(obj.Value, Camera);
            }
        }

    }
}
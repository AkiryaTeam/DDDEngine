using System.Collections.Generic;
using DDDEngine.Cameras;
using DDDEngine.Configuration;
using DDDEngine.Model;
using DDDEngine.Utils.Exceptions;

namespace DDDEngine.World
{
    public enum Direction { Left, Up, Right, Down, Back, Forward }

    public class World3D
    {
        private readonly Dictionary<IDrawable, Point3D> _objects;
        public Camera Camera { get; set; }

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

        public void Move(IDrawable obj, Direction direction, int i)
        {
            if (!_objects.ContainsKey(obj)) throw new NoSuchElementException();
            switch (direction)
            {
                case Direction.Left:
                    _objects[obj].X += i;
                    break;
                case Direction.Right:
                    _objects[obj].X -= i;
                    break;
                case Direction.Up:
                    _objects[obj].Y += i;
                    break;
                case Direction.Down:
                    _objects[obj].Y -= i;
                    break;
                case Direction.Back:
                    _objects[obj].Z -= i;
                    break;
                case Direction.Forward:
                    _objects[obj].Z += i;
                    break;
            }
            Draw();
        }

        public Point3D GetWorldPoint(IDrawable obj)
        {
            if (!_objects.ContainsKey(obj)) throw new NoSuchElementException();
            return _objects[obj];
        }
    }
}
using System;
using System.Collections.Generic;
using DDDEngine.View;
using DDDEngine.Physics;
using DDDEngine.Utils.Exceptions;

namespace DDDEngine.World
{
    public enum Direction { Left, Up, Right, Down, Back, Forward }

    public class World3D
    {
        private readonly List<RigidBody> _bodies;
        private readonly List<RigidBody> _cameras; 

        public World3D()
        {
            _bodies = new List<RigidBody>();
            _cameras = new List<RigidBody>();
        }

        public void AddBody(RigidBody body)
        {
            _bodies.Add(body);
        }

        public void AddCamera(RigidBody camera)
        {
            if (!(camera.Object is Camera)) throw new InvalidOperationException();
            _cameras.Add(camera);
        }

        public void Draw(double deltaTime)
        {
            foreach (var camera in _cameras)
            {
                var cameraObject = (Camera) camera.Object;
                cameraObject.Canvas.Children.Clear();
                foreach (var body in _bodies)
                {
                    body.Object.Draw(body.Position, camera);
                    new PhysicsProcessor().RecomputePosition(body, deltaTime);
                }
            }
        }

        public void Draw()
        {
            foreach (var camera in _cameras)
            {
                var cameraObject = (Camera) camera.Object;
                cameraObject.Canvas.Children.Clear();
                foreach (var body in _bodies)
                {
                    body.Object.Draw(body.Position, camera);
                }
            }
        }

        public void Move(RigidBody body, Direction direction, int i)
        {
            if (!_bodies.Contains(body)) throw new NoSuchElementException();
            switch (direction)
            {
                case Direction.Left:
                    body.Position.Point.X += i;
                    break;
                case Direction.Right:
                    body.Position.Point.X -= i;
                    break;
                case Direction.Up:
                    body.Position.Point.Y += i;
                    break;
                case Direction.Down:
                    body.Position.Point.Y -= i;
                    break;
                case Direction.Back:
                    body.Position.Point.Z -= i;
                    break;
                case Direction.Forward:
                    body.Position.Point.Z += i;
                    break;
            }
        }
    }
}
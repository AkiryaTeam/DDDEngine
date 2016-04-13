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
        private readonly PhysicsProcessor _physicsProcessor = new PhysicsProcessor();

        public World3D()
        {
            _bodies = new List<RigidBody>();
            _cameras = new List<RigidBody>();
        }

        public void AddBody(RigidBody body)
        {
            _bodies.Add(body);
        }

        public void ClearBodies()
        {
            _bodies.Clear();
        }

        public void AddCamera(RigidBody camera)
        {
            if (!(camera.Object is Camera)) throw new InvalidOperationException();
            _cameras.Add(camera);
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
                    _physicsProcessor.RecomputePosition(body, _bodies);
                }
            }
        }

        public void MoveBody(RigidBody body, Direction direction, int i)
        {
            if (!_bodies.Contains(body)) throw new NoSuchElementException();
            Move(body, direction, i);
        }

        public void MoveCamera(RigidBody cameraBody, Direction direction, int i)
        {
            if (!_cameras.Contains(cameraBody)) throw new NoSuchElementException();
            Move(cameraBody, direction, i);
        }

        private static void Move(RigidBody body, Direction direction, int i)
        {
            switch (direction)
            {
                case Direction.Left:
                    body.Position.Point.X -= i;
                    break;
                case Direction.Right:
                    body.Position.Point.X += i;
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
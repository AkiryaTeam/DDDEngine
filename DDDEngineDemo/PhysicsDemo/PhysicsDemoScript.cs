using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.View;
using DDDEngine.World;

namespace DDDEngineDemo.PhysicsDemo
{
    public class PhysicsDemoScript: GameScript
    {
        private readonly RigidBody _cameraBody;
        public PhysicsDemoScript(Window context, Canvas canvas) : base(context)
        {
            World = new World3D();
            _cameraBody = new RigidBody(new PerspectiveCamera(canvas), new Position(), Behaviour.Static);
            _cameraBody.Position.Point.Z = 2000;
            World.AddCamera(_cameraBody);

            ResetAndFillWorld();
        }

        public override void Action(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Thread.Sleep(10);
        }

        public void ResetAndFillWorld()
        {
            World.ClearBodies();
            var bodies = new List<RigidBody>
            {
                new RigidBody(new Plane(1200, 1200), new Position(new Point3D(0, -400, 0)), Behaviour.Static)
            };

            var amountLabel = (TextBox) Config.Get("Amount");
            var amount = int.Parse(amountLabel.Text);
            var r = new Random();

            for (var i = 0; i < amount; ++i)
            {
                bodies.Add(new RigidBody(new Cube(r.Next(50, 200)), new Position(new Point3D(r.Next(-800, 800), r.Next(-300, 1000), r.Next(-600, 600))), Behaviour.Dynamic));
            }

            bodies.ForEach(World.AddBody);
        }

        public void RotateCamera(Point2D start, Point2D end)
        {
            var point = end.Substract(start);
            _cameraBody.Position.AngleX -= point.Y % 360;
            _cameraBody.Position.AngleY += point.X % 360;
        }

        public void MoveCamera(Direction direction, int delta)
        {
            World.MoveCamera(_cameraBody, direction, delta);
        }
    }
}
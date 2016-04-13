using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.View;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.World;

namespace DDDEngineDemo
{
    public enum CameraType { Orthographic, Perspective }
    public enum ObjectType { Cube, Parallelepiped, Tetrahedron, Custom }

    public class ModelsDemoScript: GameScript
    {
        private readonly List<RigidBody> _cameras = new List<RigidBody>(2);

        public ModelsDemoScript(Window context, Canvas canvasOrthographic, Canvas canvasPerspective) : base(context)
        {
            World = new World3D();
            _cameras.Add(new RigidBody(new OrthographicCamera(canvasOrthographic), new Position(), Behaviour.Static));
            _cameras.Add(new RigidBody(new PerspectiveCamera(canvasPerspective), new Position(new Point3D(0, 0, 1000)), Behaviour.Static));
            World.AddCamera(_cameras[0]);
            World.AddCamera(_cameras[1]);
        }

        public override void Action(CancellationToken cancellationToken)
        {
            for (var i = 0; i <= 360; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                _cameras.ForEach(c =>
                {
                    c.Position.AngleY = i % 360;
                    c.Position.AngleX = i % 360;
                    c.Position.AngleZ = i % 360;
                });
                Redraw();
                Thread.Sleep(10);
            }
        }

        public void ChangeObject(ObjectType objType)
        {
            IObject obj;
            switch (objType)
            {
                case ObjectType.Cube:
                    obj = new Cube(200, 200, 200);
                    break;
                case ObjectType.Parallelepiped:
                    obj = new Parallelepiped(100, 200, 300);
                    break;
                case ObjectType.Tetrahedron:
                    obj = new Tetrahedron(200);
                    break;
                case ObjectType.Custom:
                    obj = new CustomModel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(objType), objType, null);
            }
            World.ClearBodies();
            World.AddBody(new RigidBody(obj, new Position(), Behaviour.Static));
        }
    }
}
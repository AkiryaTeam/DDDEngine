using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.View;
using DDDEngine.World;

namespace DDDEngineDemo.PhysicsDemo
{
    public class PhysicsDemoScript: GameScript
    {
         
        private readonly RigidBody _cube;
        private const double StartY = 500;

        public PhysicsDemoScript(Window context, Canvas canvas) : base(context)
        {
            World = new World3D();
            var cameraBody = new RigidBody(new PerspectiveCamera(canvas), new Position(), Behaviour.Static);
            cameraBody.Position.Point.Z = 1500;
            World.AddCamera(cameraBody);

            _cube = new RigidBody(new Cube(100), new Position(), Behaviour.Dynamic);
            _cube.Position.Point.Y = StartY;
            World.AddBody(_cube);
        }

        public override void Action(CancellationToken cancellationToken)
        {
            Thread.Sleep(10);
        }

        public void ResetCube()
        {
            _cube.Position.Point.Y = StartY;
        }
    }
}
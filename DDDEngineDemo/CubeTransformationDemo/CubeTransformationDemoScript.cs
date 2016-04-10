using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.View;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.Physics;
using DDDEngine.World;

namespace DDDEngineDemo
{
    public class CubeTransformationDemoScript: GameScript
    {
        private readonly RigidBody _cube;

        public CubeTransformationDemoScript(Window context, Canvas canvas) : base(context)
        {
            World = new World3D();
            var cameraBody = new RigidBody(new PerspectiveCamera(canvas), new Position(), Behaviour.Static);
            cameraBody.Position.Point.Z = 1300;
            World.AddCamera(cameraBody);

            _cube = new RigidBody(new Cube(200), new Position(), Behaviour.Static);
            World.AddBody(_cube);
        }

        public override void Action(CancellationToken cancellationToken)
        {
            Thread.Sleep(10);
        }

        public void MoveCube(Direction direction, int delta)
        {
            World.Move(_cube, direction, delta);
            var position = _cube.Position;

            var label = (Label) Config.Get("Label");
            label.Content = $"X: {position.Point.X:F}, Y: {position.Point.Y:F}, Z: {position.Point.Z:F}";
        }
    }
}
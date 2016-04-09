using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DDDEngine.Cameras;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.World;

namespace DDDEngineDemo
{
    public class CubeTransformationDemoScript: GameScript
    {
        public readonly Cube Cube;

        public CubeTransformationDemoScript(Window context) : base(context)
        {
            var camera = new PerspectiveCamera();
            World = new World3D(camera);

            Cube = new Cube(200);
            World.AddObject(Cube, new Point3D(0,0,0));
        }

        public override void Action(CancellationToken cancellationToken)
        {
            Thread.Sleep(10);
        }

        public void MoveCube(Direction direction, int delta)
        {
            World.Move(Cube, direction, delta);
            var worldPoint = World.GetWorldPoint(Cube);

            var label = (Label) Config.Get("Label");
            label.Content = $"X: {worldPoint.X:F}, Y: {worldPoint.Y:F}, Z: {worldPoint.Z:F}";
        }
    }
}
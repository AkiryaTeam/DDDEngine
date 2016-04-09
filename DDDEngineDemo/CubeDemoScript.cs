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
    public enum CameraType { Orthographic, Perspective }

    public class CubeDemoScript: GameScript
    {
        public CubeDemoScript(Window context) : base(context)
        {
            var camera = new OrthographicCamera();
            World = new World3D(camera);

            var cube = new Cube(200);
            World.AddObject(cube, new Point3D(0,0,0));
        }

        public override void Action(CancellationToken cancellationToken)
        {
            for (var i = 0; i <= 360; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                World.Camera.AngleY = i % 360;
                World.Camera.AngleX = i % 360;
                World.Camera.AngleZ = i % 360;
                Redraw();
                Thread.Sleep(10);
            }
        }

        public void SetCamera(CameraType type)
        {
            World.Camera = type == CameraType.Orthographic ? (Camera) new OrthographicCamera() : new PerspectiveCamera();
            var label = (Label) Config.Get("Label");
            Context.Dispatcher.Invoke(() => label.Content = type);
        }
    }
}
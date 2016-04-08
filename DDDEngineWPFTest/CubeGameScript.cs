using System.Threading;
using System.Windows;
using DDDEngine.Cameras;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.World;

namespace DDDEngineWPFTest
{
    public class CubeGameScript: GameScript
    {
        public CubeGameScript(Window context) : base(context) { }

        public override void Init()
        {
            var camera = new OrthographicCamera();
            World = new World3D(camera);

            var cube = new Cube(200);
            World.AddObject(cube, new Point3D(0,0,0));
        }

        public override void Action(CancellationToken cancellationToken)
        {
            for (var i = 0; i < 360; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                World.Camera.AngleY = i % 360;
                World.Camera.AngleX = i % 360;
                //World.Camera.AngleZ = i % 360;
                Redraw();
                Thread.Sleep(10);
            }
            World.Camera = World.Camera is OrthographicCamera
                ? (Camera) new PerspectiveCamera()
                : new OrthographicCamera();
        }
    }
}
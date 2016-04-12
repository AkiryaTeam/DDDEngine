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
    public class ParallelepipedDemoScript : GameScript
    {      
        private readonly RigidBody _cameraBody;
        private readonly Canvas _canvas;

        public ParallelepipedDemoScript(Window context, Canvas canvas)
            : base(context)
        {
            World = new World3D();
            _canvas = canvas;
            _cameraBody = new RigidBody(new OrthographicCamera(canvas), new Position(), Behaviour.Static);
            World.AddCamera(_cameraBody);

            var parallelepiped = new Parallelepiped(200, 100,200);
            var body = new RigidBody(parallelepiped, new Position(), Behaviour.Static);
            World.AddBody(body);
        }

        public override void Action(CancellationToken cancellationToken)
        {
            for (var i = 0; i <= 360; ++i)
            {
                cancellationToken.ThrowIfCancellationRequested();
                _cameraBody.Position.AngleY = i % 360;
                _cameraBody.Position.AngleX = i % 360;
                _cameraBody.Position.AngleZ = i % 360;
                Redraw();
                Thread.Sleep(10);
            }
        }

        public void SetCamera(CameraType type)
        {
            if (type == CameraType.Orthographic)
            {
                _cameraBody.Object = new OrthographicCamera(_canvas);
            }
            else
            {
                _cameraBody.Object = new PerspectiveCamera(_canvas);
                _cameraBody.Position.Point.Z = 1300;
            }
            var label = (Label)Config.Get("Label");
            Context.Dispatcher.Invoke(() => label.Content = type);
        }
        
    }
}

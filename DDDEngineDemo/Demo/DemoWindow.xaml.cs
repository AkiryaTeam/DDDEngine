using System.ComponentModel;
using System.Windows;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;

namespace DDDEngineDemo
{
    public partial class DemoWindow
    {
        private  GameLoop _gameOrthographic;
        private  GameLoop _gamePerspective;
        private  DemoScript _scriptOrthographic;
        private  DemoScript _scriptPerspective;
        private State _stateOrthographic = State.Stop;
        private State _statePerspective = State.Stop;

        public DemoWindow()
        {
            InitializeComponent();
            Config.Clear();
            //Config.Add("Label",Label);
            _scriptOrthographic = new DemoScript(this, Canvas_Orthographic, new Cube(50, 50,50));
            _scriptPerspective = new DemoScript(this, Canvas_Perspective, new Cube(100, 100,100));
            _gameOrthographic = new GameLoop(_scriptOrthographic);
            _gamePerspective = new GameLoop(_scriptPerspective);
        }

        private void StartGameOrthographic()
        {
            if (_stateOrthographic != State.Stop) return;
            _gameOrthographic.Start();
            _stateOrthographic = State.Game;
        }
        private void StartGamePerspective()
        {
            if (_statePerspective != State.Stop) return;
            _gamePerspective.Start();
            _statePerspective = State.Game;
        }
        private void StopGameOrthographic()
        {
            if (_stateOrthographic != State.Game) return;
            _gameOrthographic.Stop();
            _stateOrthographic = State.Stop;
        }
        private void StopGamePerspective()
        {
            if (_statePerspective != State.Game) return;
            _gamePerspective.Stop();
            _statePerspective = State.Stop;
        }
        private void Dispose(object sender, CancelEventArgs e)
        {
            StopGameOrthographic();
            StopGamePerspective();
        }

        private void SetCameraOrthographic(CameraType type)
        {
            StopGameOrthographic();
            _scriptOrthographic.SetCamera(type);
            StartGameOrthographic();
        }
        private void SetCameraPerspective(CameraType type)
        {
            StopGamePerspective();
            _scriptPerspective.SetCamera(type);
            StartGamePerspective();
        }
        private void SetOrthographic(object sender, RoutedEventArgs e)
        {
            SetCameraOrthographic(CameraType.Orthographic);
        }

        private void SetPerspective(object sender, RoutedEventArgs e)
        {
            SetCameraPerspective(CameraType.Perspective);
        }

        private void BuildCube(object sender, RoutedEventArgs e)
        {
            _scriptOrthographic = new DemoScript(this, Canvas_Orthographic, new Cube(100, 100,100));
            _scriptPerspective = new DemoScript(this, Canvas_Perspective, new Cube(150, 150,150));
            _gameOrthographic = new GameLoop(_scriptOrthographic);
            _gamePerspective = new GameLoop(_scriptPerspective);
            SetCameraOrthographic(CameraType.Orthographic);
            SetCameraPerspective(CameraType.Perspective);
        }

        private void BuildParallelepiped(object sender, RoutedEventArgs e)
        {
            _scriptOrthographic = new DemoScript(this, Canvas_Orthographic, new Parallelepiped(100, 200,300));
            _scriptPerspective = new DemoScript(this, Canvas_Perspective, new Parallelepiped(150, 250,350));
            _gameOrthographic = new GameLoop(_scriptOrthographic);
            _gamePerspective = new GameLoop(_scriptPerspective);
            SetCameraOrthographic(CameraType.Orthographic);
            SetCameraPerspective(CameraType.Perspective);
        }
        private void BuildTetrahedron(object sender, RoutedEventArgs e)
        {
            _scriptOrthographic = new DemoScript(this, Canvas_Orthographic, new Tetrahedron(100));
            _scriptPerspective = new DemoScript(this, Canvas_Perspective, new Tetrahedron(150));
            _gameOrthographic = new GameLoop(_scriptOrthographic);
            _gamePerspective = new GameLoop(_scriptPerspective);
            SetCameraOrthographic(CameraType.Orthographic);
            SetCameraPerspective(CameraType.Perspective);
        }
        private void BuildMyModel(object sender, RoutedEventArgs e)
        {
            _scriptOrthographic = new DemoScript(this, Canvas_Orthographic, new MyModel());
            _scriptPerspective = new DemoScript(this, Canvas_Perspective, new MyModel());
            _gameOrthographic = new GameLoop(_scriptOrthographic);
            _gamePerspective = new GameLoop(_scriptPerspective);
            SetCameraOrthographic(CameraType.Orthographic);
            SetCameraPerspective(CameraType.Perspective);
        }
    }
}

using System.ComponentModel;
using System.Windows;
using DDDEngine.Configuration;
using DDDEngine.Game;

namespace DDDEngineDemo
{
    public partial class CubeDemoWindow
    {
        private readonly GameLoop _game;
        private readonly CubeDemoScript _script;
        private State _state = State.Stop;

        public CubeDemoWindow()
        {
            InitializeComponent();
            Config.Clear();
            Config.Canvas = Canvas;
            Config.Add("Label", Label);

            _script = new CubeDemoScript(this);
            _game = new GameLoop(_script);
        }

        private void StartGame()
        {
            if (_state != State.Stop) return;
            _game.Start();
            _state = State.Game;
        }

        private void StopGame()
        {
            if (_state != State.Game) return;
            _game.Stop();
            _state = State.Stop;
        }

        private void Dispose(object sender, CancelEventArgs e)
        {
            StopGame();
        }

        private void SetCamera(CameraType type)
        {
            StopGame();
            _script.SetCamera(type);
            StartGame();
        }

        private void SetOrthographic(object sender, RoutedEventArgs e)
        {
            SetCamera(CameraType.Orthographic);
        }

        private void SetPerspective(object sender, RoutedEventArgs e)
        {
            SetCamera(CameraType.Perspective);
        }
    }
}

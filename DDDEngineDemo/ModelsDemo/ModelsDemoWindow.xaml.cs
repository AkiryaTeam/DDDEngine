using System.ComponentModel;
using System.Windows;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngineDemo.ModelsDemo;

namespace DDDEngineDemo
{
    public partial class ModelsDemoWindow
    {
        private readonly GameLoop _game;
        private readonly ModelsDemoScript _script;
        private State _state = State.Stop;

        public ModelsDemoWindow()
        {
            InitializeComponent();
            Config.Clear();
            _script = new ModelsDemoScript(this, CanvasOrthographic, CanvasPerspective);
            _game = new GameLoop(_script);
            StartGame();
        }

        private void StartGame()
        {
            if (_state == State.Game) return;
            _game.Start();
            _state = State.Game;
        }

        private void StopGame()
        {
            if (_state == State.Stop) return;
            _game.Stop();
            _state = State.Stop;
        }

        private void Dispose(object sender, CancelEventArgs e)
        {
            StopGame();
        }

        private void ChangeObject(ObjectType objType)
        {
            _game.Restart(() => _script.ChangeObject(objType));
        }

        private void ChangeToCube(object sender, RoutedEventArgs e)
        {
            ChangeObject(ObjectType.Cube);
        }

        private void ChangeToParallelepiped(object sender, RoutedEventArgs e)
        {
            ChangeObject(ObjectType.Parallelepiped);
        }

        private void ChangeToTetrahedron(object sender, RoutedEventArgs e)
        {
            ChangeObject(ObjectType.Tetrahedron);
        }

        private void ChangeToCustom(object sender, RoutedEventArgs e)
        {
            ChangeObject(ObjectType.Custom);
        }
    }
}

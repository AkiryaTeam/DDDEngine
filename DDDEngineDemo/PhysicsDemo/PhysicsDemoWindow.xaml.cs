using System.ComponentModel;
using System.Windows;
using DDDEngine.Configuration;
using DDDEngine.Game;

namespace DDDEngineDemo.PhysicsDemo
{
    public partial class PhysicsDemoWindow
    {
        private readonly GameLoop _game;
        private readonly PhysicsDemoScript _script;

        public PhysicsDemoWindow()
        {
            InitializeComponent();

            Config.Clear();

            _script = new PhysicsDemoScript(this, Canvas);
            _game = new GameLoop(_script);
            _game.Start();
        }

        private void Dispose(object sender, CancelEventArgs e)
        {
            _game.Stop();
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            _game.Stop();
            _script.ResetCube();
            Config.G = double.Parse(TextBox.Text);
            _game.Start();
        }
    }
}

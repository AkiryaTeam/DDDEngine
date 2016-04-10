using System.ComponentModel;
using System.Windows.Input;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.World;

namespace DDDEngineDemo
{
    public partial class CubeTransformationDemoWindow
    {
        private readonly GameLoop _game;
        private readonly CubeTransformationDemoScript _script;

        public CubeTransformationDemoWindow()
        {
            InitializeComponent();

            Config.Clear();
            Config.Add("Label", Label);

            _script = new CubeTransformationDemoScript(this, Canvas);
            _game = new GameLoop(_script);
            _game.Start();
        }

        private void MoveCube(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            var direction = Direction.Left;
            switch (key)
            {
                case Key.Left:
                    direction = Direction.Left;
                    break;
                case Key.Right:
                    direction = Direction.Right;
                    break;
                case Key.Up:
                    direction = Direction.Up;
                    break;
                case Key.Down:
                    direction = Direction.Down;
                    break;
            }
            _script.MoveCube(direction, 5);
        }

        private void MoveCube(object sender, MouseWheelEventArgs e)
        {
            var delta = e.Delta/12;
            if (delta > 0)
            {
                _script.MoveCube(Direction.Forward, delta);
            }
            else
            {
                _script.MoveCube(Direction.Back, -delta);
            }
        }

        private void Dispose(object sender, CancelEventArgs e)
        {
            _game.Stop();
        }
    }
}

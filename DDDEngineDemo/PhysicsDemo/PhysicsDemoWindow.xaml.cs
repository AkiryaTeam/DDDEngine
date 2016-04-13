using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.World;
using DDDEngineDemo.Utils;

namespace DDDEngineDemo.PhysicsDemo
{
    public partial class PhysicsDemoWindow
    {
        private readonly GameLoop _game;
        private readonly PhysicsDemoScript _script;
        private readonly Point2D _startPoint = new Point2D();

        public PhysicsDemoWindow()
        {
            InitializeComponent();

            Config.Clear();
            Config.Add("Amount", Amount);

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
            _script.ResetAndFillWorld();
            Config.G = double.Parse(TextBox.Text);
            _game.Start();
        }

        private void RotateCamera(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(Canvas);
            var point = Converter.PositionToPoint2D(Canvas, position);

            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                _script.RotateCamera(_startPoint, point);
            }
            _startPoint.X = point.X;
            _startPoint.Y = point.Y;
        }

        private void MoveCamera(object sender, MouseWheelEventArgs e)
        {
            var delta = e.Delta/12;
            if (delta > 0)
            {
                _script.MoveCamera(Direction.Forward, -delta);
            }
            else
            {
                _script.MoveCamera(Direction.Back, delta);
            }
        }
    }
}

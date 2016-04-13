using System.ComponentModel;
using System.Windows.Input;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngine.World;
using DDDEngineDemo.CubeTransformationDemo;
using DDDEngineDemo.Utils;

namespace DDDEngineDemo
{
    public partial class CubeTransformationDemoWindow
    {
        private readonly GameLoop _game;
        private readonly CubeTransformationDemoScript _script;
        private readonly Point2D _startPoint = new Point2D();

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

        private void MoveCube(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(Canvas);
            var point = Converter.PositionToPoint2D(Canvas, position);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _script.MoveCube(_startPoint, point);
            }
            else if (e.MiddleButton == MouseButtonState.Pressed)
            {
                _script.RotateCube(_startPoint, point);
            }
            _startPoint.X = point.X;
            _startPoint.Y = point.Y;
        }

        private void SetStartPoint(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(Canvas);
            _startPoint.X = position.X - Canvas.ActualWidth/2;
            _startPoint.Y = -position.Y + Canvas.ActualHeight/2;
        }
    }
}

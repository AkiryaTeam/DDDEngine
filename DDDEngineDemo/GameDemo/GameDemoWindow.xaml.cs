using System.ComponentModel;
using System.Windows.Input;
using DDDEngine.Configuration;
using DDDEngine.Game;
using DDDEngine.Model;
using DDDEngineDemo.Utils;

namespace DDDEngineDemo.GameDemo
{
    public partial class GameDemoWindow
    {
        private readonly GameLoop _game;
        private readonly GameDemoScript _script;
        private readonly Point2D _startPoint = new Point2D();

        public GameDemoWindow()
        {
            InitializeComponent();

            Config.Clear();
            Config.Add("Label", Label);

            _script = new GameDemoScript(this, Canvas);
            _game = new GameLoop(_script);
            _game.Start();
        }

        private void Dispose(object sender, CancelEventArgs e)
        {
            _game.Stop();
        }

        private void MoveBasket(object sender, MouseEventArgs e)
        {
            var position = e.GetPosition(Canvas);
            var point = Converter.PositionToPoint2D(Canvas, position);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                _script.MoveBasket(_startPoint, point);
            }
            _startPoint.X = point.X;
            _startPoint.Y = point.Y;
        }
    }
}

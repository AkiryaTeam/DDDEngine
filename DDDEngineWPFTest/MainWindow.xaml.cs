using System.Windows;
using DDDEngine.Configuration;
using DDDEngine.Game;

namespace DDDEngineWPFTest
{
    internal enum State { Game, Stop }

    public partial class MainWindow
    {
        private readonly GameLoop _game;
        private State _state = State.Stop;

        public MainWindow()
        {
            InitializeComponent();
            Config.Initialize(Canvas);
            Config.Add("Label", Label);

            var script = new CubeGameScript(this);
            _game = new GameLoop(script);
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            if (_state == State.Stop)
            {
                _game.Start();
                _state = State.Game;
            }
            else
            {
                _game.Stop();
                _state = State.Stop;
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace DDDEngine.Game
{
    public class GameLoop
    {
        private readonly GameScript _script;
        private CancellationTokenSource _cancellationTokenSource;

        public GameLoop(GameScript script)
        {
            _script = script;
        }

        public void Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            Task.Run(() =>
            {
                try
                {
                    _script.Init();
                    while (true)
                    {   
                        cancellationToken.ThrowIfCancellationRequested();
                        _script.Action(cancellationToken);
                        _script.Redraw();
                    }
                }
                catch (Exception) { /*ignore*/ }
            }, cancellationToken);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
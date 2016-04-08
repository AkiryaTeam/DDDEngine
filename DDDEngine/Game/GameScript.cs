using System.Threading;
using System.Windows;
using DDDEngine.World;

namespace DDDEngine.Game
{
    public abstract class GameScript
    {
        public readonly Window Context;
        public World3D World;

        protected GameScript(Window context)
        {
            Context = context;
        }

        public virtual void Init() {}
        public abstract void Action(CancellationToken cancellationToken);

        public void Redraw()
        {
            Context.Dispatcher.Invoke(World.Draw);
        }
    }
}
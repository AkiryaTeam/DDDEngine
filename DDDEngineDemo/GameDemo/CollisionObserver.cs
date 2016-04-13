using System;
using DDDEngine.Physics;

namespace DDDEngineDemo.GameDemo
{
    public class CollisionObserver: IObserver<Collision>
    {
        private readonly GameDemoScript _script;

        public CollisionObserver(GameDemoScript script)
        {
            _script = script;
        }

        public void OnNext(Collision value)
        {
            _script.CollisionDetected(value);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DDDEngine.Configuration;
using DDDEngine.Model;
using static System.Math;

namespace DDDEngine.Physics
{
    public class PhysicsProcessor: IObservable<Collision>
    {
        private readonly Dictionary<RigidBody, Stopwatch> _bodyTime = new Dictionary<RigidBody, Stopwatch>(); 
        private readonly List<IObserver<Collision>> _observers = new List<IObserver<Collision>>(); 

        public void RecomputePosition(RigidBody body, List<RigidBody> bodies)
        {
            if (body.Behaviour != Behaviour.Dynamic) return;

            if (!_bodyTime.ContainsKey(body))
            {
                _bodyTime.Add(body, Stopwatch.StartNew());
            }

            var stopwatch = _bodyTime[body];
            var newY = ComputeNewY(body, stopwatch);

            var aBox = body.GetBoundingBox();
            aBox.Center.Y = newY;

            var intersect = ComputeIntersection(body, bodies, aBox);

            if (!intersect)
            {
                body.Position.Point.Y = newY;
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }
            }
            else
            {
                stopwatch.Reset();
            }
        }

        private bool ComputeIntersection(RigidBody body, List<RigidBody> bodies, BoundingBox aBox)
        {
            var intersect = false;

            foreach (var b in bodies)
            {
                if (b == body) continue;
                var bBox = b.GetBoundingBox();
                intersect = Intersect(aBox, bBox);
                if (intersect)
                {
                    foreach (var observer in _observers)
                    {
                        observer.OnNext(new Collision(body, b));
                    }
                    break;
                }
            }
            return intersect;
        }

        private static double ComputeNewY(RigidBody body, Stopwatch stopwatch)
        {
            var t = stopwatch.ElapsedMilliseconds/500.0;
            var oldY = body.Position.Point.Y;
            var newY = oldY - Config.G*t*t/2;
            return newY;
        }

        private static bool Intersect(BoundingBox a, BoundingBox b)
        {
            var x = Abs(a.Center.X - b.Center.X) <= a.HalfWidth.X + b.HalfWidth.X;
            var y = Abs(a.Center.Y - b.Center.Y) <= a.HalfWidth.Y + b.HalfWidth.Y;
            var z = Abs(a.Center.Z - b.Center.Z) <= a.HalfWidth.Z + b.HalfWidth.Z;
            return x && y && z;
        }

        public IDisposable Subscribe(IObserver<Collision> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private readonly List<IObserver<Collision>> _observers;
            private readonly IObserver<Collision> _observer;

            public Unsubscriber(List<IObserver<Collision>> observers, IObserver<Collision> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observers != null && _observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
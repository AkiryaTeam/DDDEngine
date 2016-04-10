using DDDEngine.Configuration;

namespace DDDEngine.Physics
{
    public class PhysicsProcessor
    {
        public void RecomputePosition(RigidBody body, double t)
        {
            t = t/500;
            if (body.Behaviour != Behaviour.Dynamic) return;
            var h0 = body.Position.Point.Y;
            body.Position.Point.Y = h0 - Config.G * t * t / 2;
        }
    }
}
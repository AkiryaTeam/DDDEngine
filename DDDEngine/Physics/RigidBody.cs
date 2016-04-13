using DDDEngine.Model;

namespace DDDEngine.Physics
{
    public enum Behaviour { Static, Dynamic }

    public class RigidBody
    {
        public IObject Object { get; set; }
        public Position Position { get; set; }
        public Behaviour Behaviour { get; set; }
        public double Weight { get; set; }

        public RigidBody(IObject obj, Position pos, Behaviour behaviour)
        {
            Object = obj;
            Position = pos;
            Behaviour = behaviour;
        }

        public BoundingBox GetBoundingBox()
        {
            return Object.GetBoundingBox(Position);
        }
    }
}

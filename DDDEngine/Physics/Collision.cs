namespace DDDEngine.Physics
{
    public class Collision
    {
        public RigidBody One { get; }
        public RigidBody Two { get; }

        public Collision(RigidBody one, RigidBody two)
        {
            One = one;
            Two = two;
        }
    }
}
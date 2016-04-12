using DDDEngine.Physics;
using System.Collections.Generic;

namespace DDDEngine.Model
{
    public abstract class IObject
    {
        protected  List<Line> _lines;
        public void Draw(Position position, RigidBody camera)
        {
            _lines.ForEach(l => l.Draw(position, camera));
        }
    }
}
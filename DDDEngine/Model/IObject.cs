﻿using DDDEngine.Physics;

namespace DDDEngine.Model
{
    public interface IObject
    {
        void Draw(Position position, RigidBody camera);
        Box GetBoundingBox(Position position);
    }
}
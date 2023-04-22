using UnityEngine;

namespace Assets.Sources.Services
{
    public class MovementService
    {
        public Vector3 Direction { get; private set; }

        public MovementService AddDirection(Vector3 direction)
        {
            Direction += direction;
            return this;
        }

        public MovementService Normalize()
        {
            Direction = Direction.normalized;
            return this;
        }

        public MovementService Clear()
        {
            Direction = Vector3.zero;
            return this;
        }
    }
}
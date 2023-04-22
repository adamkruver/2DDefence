using UnityEngine;

namespace Sources.Common
{
    public interface IMovable
    {
        Vector2 Position { get; }
        Vector2 Direction { get; }
    }
}
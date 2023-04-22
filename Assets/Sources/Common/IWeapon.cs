using UnityEngine;

namespace Sources.Common
{
    public interface IWeapon
    {
        float BulletSpeed { get; }
        Vector2 AttackPoint { get; }
    }
}
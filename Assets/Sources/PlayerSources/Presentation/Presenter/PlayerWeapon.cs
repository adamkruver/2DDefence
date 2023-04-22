using Sources.Common;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Presenter
{
    public class PlayerWeapon: MonoBehaviour, IWeapon
    {
        [field: SerializeField] public float BulletSpeed { get; private set; }
        public Vector2 AttackPoint => transform.position;
    }
}
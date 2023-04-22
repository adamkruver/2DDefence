using Sources.Common;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Presenter.Component
{
    public class TargetPositionPredictor : MonoBehaviour
    {
        [SerializeField] private PlayerWeapon _weapon; 
        
        public Vector2 TryInterceptDirection(IMovable target)
        {
            Vector2 directionToTarget = (target.Position - (Vector2)transform.position).normalized;
            Vector2 targetOrthVelocity = Vector3.Dot(target.Direction, directionToTarget) *
                                         directionToTarget;
            Vector2 targetTangVelocity = target.Direction - targetOrthVelocity;

            Vector2 shotTangVelocity = targetTangVelocity;
            Vector2 shotOrthVelocity = directionToTarget * Mathf.Sqrt(_weapon.BulletSpeed * _weapon.BulletSpeed -
                                                                      shotTangVelocity.sqrMagnitude);

            Vector2 shotDirection = (shotTangVelocity + shotOrthVelocity).normalized;
            return shotDirection + _weapon.AttackPoint;
        }
    }
}
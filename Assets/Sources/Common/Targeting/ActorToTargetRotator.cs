using Assets.Sources.PlayerSources.Presentation.Presenter;
using Assets.Sources.PlayerSources.Presentation.Presenter.Component;
using Sources.Common;
using UnityEngine;

namespace Assets.Sources.Common.Targeting
{
    public class ActorToTargetRotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1f;
        [SerializeField] private Transform _actor;
        [SerializeField] private TargetTracker _targetTracker;
        [SerializeField] private TargetPositionPredictor _targetPositionPredictor;
        [SerializeField] private FireGun _fireGun;

        private void Update()
        {
            if (_actor is null)
            {
                _fireGun.Stop();
                return;
            }

            if (_targetTracker?.Target is null)
            {
                _fireGun.Stop();
                return;
            }
            
            _fireGun.Fire();

            IMovable movableTarget = _targetTracker.Target.GetComponent<IMovable>();

            Vector2 targetPosition;

            if (movableTarget is null)
            {
                targetPosition = _targetTracker.Target.position - _actor.position;
            }
            else
            {
                targetPosition = _targetPositionPredictor.TryInterceptDirection(movableTarget) -
                                 (Vector2)_actor.position;
            }

            RotateToPosition(targetPosition);
        }

        private void RotateToPosition(Vector2 position)
        {
            _actor.transform.up = 
                Vector2.MoveTowards(_actor.transform.up, position, _rotationSpeed * Time.deltaTime);
        }
    }
}
using UnityEngine;

namespace Assets.Sources.Common.Targeting
{
    public class ActorToTargetRotator : MonoBehaviour
    {
        [SerializeField] private Transform _actor;
        [SerializeField] private TargetTracker _targetTracker;

        private void Update()
        {
            if (_actor is null)
                return;

            if (_targetTracker?.Target is null)
                return;

            _actor.transform.up = _targetTracker.Target.position - _actor.position;
        }
    }
}
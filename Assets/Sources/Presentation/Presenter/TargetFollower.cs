using UnityEngine;

namespace DefaultNamespace
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private TargetTracker _targetTracker;

        private void Update()
        {
            if (_player is null)
                return;

            if (_targetTracker?.Target is null)
                return;

            _player.transform.up = _targetTracker.Target.position - _player.position;
        }
    }
}
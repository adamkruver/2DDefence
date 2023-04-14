using UnityEngine;

namespace DefaultNamespace
{
    public class SpiderPresenter : MonoBehaviour
    {
        [SerializeField] private float _spiderSpeed = 2;
        
        private Vector3? _target;
        private TreasurePresenter _treasurePresenter;

        public void Update()
        {
            MoveToTarget(_target ?? _treasurePresenter.transform.position);
        }

        public void Construct(TreasurePresenter treasurePresenter, Vector3 spawnPosition)
        {
            _treasurePresenter = treasurePresenter;
            transform.position = spawnPosition;
        }

        public void Attack(Vector3? target)
        {
            _target = target;
        }
        
        private void MoveToTarget(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _spiderSpeed * Time.deltaTime);
            transform.up = target - transform.position;
        }
    }
}
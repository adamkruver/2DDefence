using Assets.Sources.Common.HealthPoints;
using Assets.Sources.Enemy.SpiderSources.Domain;
using Assets.Sources.Presentation.Presenter;
using Sources.Common;
using Sources.Common.Pool;
using UnityEngine;

namespace Assets.Sources.Enemy.SpiderSources.Presentation.Presenter
{
    public class SpiderPresenter : PoolBehaviour,IMovable
    {
        [SerializeField] private float _spiderSpeed = 2;
        [SerializeField] private HealthBar _healthBar;

        private Vector3? _target;
        private TreasureProvider _treasureProvider;
        private Spider _spider;

        public Vector2 Position => transform.position;
        public Vector2 Direction => transform.up.normalized * _spiderSpeed;

        public void Update()
        {
            if (_spider is null)
                return;

            MoveToTarget(_target ?? _treasureProvider.Transform.position);
            _healthBar.transform.up = Vector3.up;
        }

        public void Construct(Spider spider, TreasureProvider treasureProvider, Vector3 spawnPosition)
        {
            _spider = spider;
            transform.position = spawnPosition;
            _treasureProvider = treasureProvider;
            _spider.HealthChanged += OnHealthChanged;
            _spider.Died += OnDied;
            _healthBar.Clear();
        }

        public void TakeDamage(int damage)
        {
            _spider.Hit(damage);
        }

        public void Attack(Vector3? target)
        {
            _target = target;
        }

        private void OnDied(Spider spider)
        {
            _spider.HealthChanged -= OnHealthChanged;
            _spider.Died -= OnDied;

            Release();
        }

        private void OnHealthChanged(int currentHealth, float percent)
        {
            _healthBar.Set(percent);
        }

        private void MoveToTarget(Vector3 target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, _spiderSpeed * Time.deltaTime);
            transform.up = target - transform.position;
        }
    }
}
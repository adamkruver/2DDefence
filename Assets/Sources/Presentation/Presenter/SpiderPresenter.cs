using System;
using Assets.Sources.Domain;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpiderPresenter : MonoBehaviour
    {
        [SerializeField] private float _spiderSpeed = 2;
        [SerializeField] private HealthBar _healthBar;
        
        private Vector3? _target;
        private TreasurePresenter _treasurePresenter;
        private Spider _spider;

        private void Awake()
        {
            _spider = new Spider();
        }

        private void OnEnable()
        {
            _spider.HealthChanged += OnHealthChanged;
            _spider.Died += OnDied;
        }

        private void OnDisable()
        {
            _spider.HealthChanged -= OnHealthChanged;
            _spider.Died -= OnDied;
        }

        public void Update()
        {
            MoveToTarget(_target ?? _treasurePresenter.transform.position);
            _healthBar.transform.up = Vector3.up;
        }

        public void Construct(TreasurePresenter treasurePresenter, Vector3 spawnPosition)
        {
            _treasurePresenter = treasurePresenter;
            transform.position = spawnPosition;
        }

        public void TakeDamage(int damage)
        {
            _spider.Hit(damage);
        }
        
        public void Attack(Vector3? target)
        {
            _target = target;
        }

        private void OnDied()
        {
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
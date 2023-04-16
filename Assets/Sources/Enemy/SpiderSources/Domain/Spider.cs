using System;
using Assets.Sources.Common.HealthPoints;

namespace Assets.Sources.Enemy.SpiderSources.Domain
{
    public class Spider
    {
        private Health _health;

        public Spider()
        {
            _health = new Health(10000);
            _health.Died += OnDied;
        }

        private void OnDied()
        {
            Dispose();
            Died?.Invoke(this);
        }

        public event Action<int, float> HealthChanged
        {
            add => _health.Changed += value;
            remove => _health.Changed -= value;
        }

        public event Action<Spider> Died;

        public void Hit(int damage)
        {
            _health.Hit(damage);
        }

        private void Dispose()
        {
            _health.Died -= OnDied;
        }
    }
}
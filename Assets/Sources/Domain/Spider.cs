using System;
using UnityEngine;

namespace Assets.Sources.Domain
{
    public class Spider
    {
        private Health _health= new Health(10000);
        
        public event Action<int, float> HealthChanged
        {
            add => _health.Changed += value;
            remove => _health.Changed -= value;
        }
        
        public event Action Died
        {
            add => _health.Died += value;
            remove => _health.Died -= value;
        }

        public void Hit(int damage)
        {
            _health.Hit(damage);
        }
    }
}
using System;

namespace UnityEngine
{
    public class Health
    {
        private readonly int _max;
        private int _value;

        public Health(int max)
        {
            _max = max;
            _value = _max;
        }

        public event Action<int, float> Changed;
        public event System.Action Died;

        public int Value
        {
            get => _value;
            private set
            {
                _value = Mathf.Clamp(value, 0, _max);

                Debug.Log(_value);
                
                Changed?.Invoke(_value, (float)_value / (float)_max);
                
                if(_value == 0)
                    Died?.Invoke();
            }
        }

        public void Hit(int damage)
        {
            if (damage <= 0)
                return;

            Value -= damage;
        }

        public void Heal(int health)
        {
            if (health <= 0)
                return;

            Value += health;
        }
    }
}
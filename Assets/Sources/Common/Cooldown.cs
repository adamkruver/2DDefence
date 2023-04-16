using Assets.Sources.Common;

namespace UnityEngine
{
    public class Cooldown: IUpdatable
    {
        private readonly float _cooldown;
        private readonly System.Action _callback;

        private float _time = 0;

        public Cooldown(float cooldown, System.Action callback)
        {
            _cooldown = cooldown;
            _callback = callback;
        }

        public void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _cooldown)
            {
                _callback.Invoke();
                _time = 0;
            }
        }
    }
}
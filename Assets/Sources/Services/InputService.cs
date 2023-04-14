using System;
using Assets.Sources.Settings;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Services
{
    public class InputService : IUpdatable
    {
        private readonly InputSetting _inputSetting;
        
        public InputService(InputSetting inputSetting)
        {
            _inputSetting = inputSetting;
        }

        public event Action<KeyCode> KeyDown;
        public event Action<KeyCode> KeyPressed;
        public event Action<KeyCode> KeyUp;

        public bool IsEnabled { get; private set; }

        public void Enable()
        {
            IsEnabled = true;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        private void TryGetKey()
        {
            Func<KeyCode>[] keyCodes = _inputSetting.KeyCodes;
            
            foreach (Func<KeyCode> keyCode in keyCodes)
            {
                KeyCode key = keyCode.Invoke();
                
                if (Input.GetKeyDown(key))
                {
                    KeyDown?.Invoke(key);
                }               
                
                if (Input.GetKey(key))
                {
                    KeyPressed?.Invoke(key);
                }
                
                if (Input.GetKeyUp(key))
                {
                    KeyUp?.Invoke(key);
                }               
            }
        }

        public void Update()
        {
            TryGetKey();
        }
    }
}
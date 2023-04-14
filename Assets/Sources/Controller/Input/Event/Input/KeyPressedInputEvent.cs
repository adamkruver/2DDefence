using Assets.Sources.Common.MVC;
using UnityEngine;

namespace Assets.Sources.Controller.Input.Event
{
    public class KeyPressedInputEvent : IControllerEvent
    {
        public KeyPressedInputEvent(KeyCode key, bool isInputEnabled)
        {
            Key = key;
            IsInputEnabled = isInputEnabled;
        }

        public KeyCode Key { get; }
        public bool IsInputEnabled { get; }
    }
}
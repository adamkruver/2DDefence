using UnityEngine;

namespace Assets.Sources.Controller.Input.Event
{
    public class KeyDownInputEvent : KeyPressedInputEvent
    {
        public KeyDownInputEvent(KeyCode key, bool isInputEnabled) : base(key, isInputEnabled)
        {
        }
    }
}
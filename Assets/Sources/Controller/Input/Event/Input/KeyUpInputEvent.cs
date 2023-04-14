using Assets.Sources.Controller.Input.Event;
using UnityEngine;

namespace Sources.Controller.Input.Event
{
    public class KeyUpInputEvent : KeyPressedInputEvent
    {
        public KeyUpInputEvent(KeyCode key, bool isInputEnabled) : base(key, isInputEnabled)
        {
        }
    }
}
using Assets.Sources.Controller.Player.Event;
using UnityEngine;

namespace Sources.Controller.Input.Event.Handle
{
    public class KeyUpEvent : KeyPressedEvent
    {
        public KeyUpEvent(KeyCode key) : base(key)
        {
        }
    }
}
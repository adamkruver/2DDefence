using Assets.Sources.Controller.Player.Event;
using UnityEngine;

namespace Sources.Controller.Input.Event
{
    public class KeyDownEvent: KeyPressedEvent
    {
        public KeyDownEvent(KeyCode key) : base(key)
        {
        }
    }
}
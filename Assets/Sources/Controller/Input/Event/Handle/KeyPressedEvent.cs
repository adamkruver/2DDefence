using Assets.Sources.Common.MVC;
using UnityEngine;

namespace Assets.Sources.Controller.Player.Event
{
    public class KeyPressedEvent : IControllerEvent
    {
        public KeyCode Key { get; }

        public KeyPressedEvent(KeyCode key)
        {
            Key = key;
        }
    }
}
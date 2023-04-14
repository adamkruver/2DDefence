using System;
using System.Collections.Generic;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Settings;
using UnityEngine;

namespace Assets.Sources.Controller.Input.Action
{
    public class HandleKeyInputAction : IControllerAction<KeyPressedInputEvent>
    {
        private readonly InputSetting _inputSetting;

        public HandleKeyInputAction(InputSetting inputSetting)
        {
            _inputSetting = inputSetting;
        }

        public void Handle(KeyPressedInputEvent @event, IDispatcher dispatcher)
        {
            Dictionary<KeyCode, Action<IDispatcher>> reservedKeys =
                new Dictionary<KeyCode, Action<IDispatcher>>()
                {
                };

            if (reservedKeys.ContainsKey(@event.Key))
            {
                reservedKeys[@event.Key].Invoke(dispatcher);
                return;
            }

            if (@event.IsInputEnabled)
                dispatcher.Dispatch(new KeyPressedEvent(@event.Key));
        }
    }
}
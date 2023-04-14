using System;
using System.Collections.Generic;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Settings;
using Sources.Controller.Input.Event;
using UnityEngine;

namespace Assets.Sources.Controller.Input.Action
{
    public class HandleKeyDownInputAction : IControllerAction<KeyDownInputEvent>
    {
        private readonly InputSetting _inputSetting;

        public HandleKeyDownInputAction(InputSetting inputSetting)
        {
            _inputSetting = inputSetting;
        }

        public void Handle(KeyDownInputEvent @event, IDispatcher dispatcher)
        {
            Dictionary<KeyCode, Action<IDispatcher>> reservedKeys =
                new Dictionary<KeyCode, Action<IDispatcher>>()
                {
                    [_inputSetting.EnableInput.Invoke()] = dispatcher => dispatcher.Dispatch(new EnableInputEvent()),
                    [_inputSetting.DisableInput.Invoke()] = dispatcher => dispatcher.Dispatch(new DisableInputEvent()),
                    [_inputSetting.Exit.Invoke()] = dispatcher => dispatcher.Dispatch(new ExitEvent()),
                };

            if (reservedKeys.ContainsKey(@event.Key))
            {
                reservedKeys[@event.Key].Invoke(dispatcher);
                return;
            }

            if (@event.IsInputEnabled)
                dispatcher.Dispatch(new KeyDownEvent(@event.Key));
        }
    }
}
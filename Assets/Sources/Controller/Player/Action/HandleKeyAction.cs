using System.Collections.Generic;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Settings;
using UnityEngine;

namespace Assets.Sources.Controller.Player.Action
{
    public class HandleKeyAction : IControllerAction<KeyPressedEvent>
    {
        private readonly InputSetting _inputSetting;
        private readonly Move _move;

        public HandleKeyAction(InputSetting inputSetting, Move move)
        {
            _inputSetting = inputSetting;
            _move = move;
        }

        public void Handle(KeyPressedEvent pressedEvent, IDispatcher dispatcher)
        {
            Vector2 direction = Vector2.zero;

            Dictionary<KeyCode, System.Action> actions =
                new Dictionary<KeyCode, System.Action>()
                {
                    [_inputSetting.PlayerMoveUp.Invoke()] = () => direction += Vector2.up,
                    [_inputSetting.PlayerMoveDown.Invoke()] = () => direction -= Vector2.up,
                    [_inputSetting.PlayerMoveLeft.Invoke()] = () => direction += Vector2.left,
                    [_inputSetting.PlayerMoveRight.Invoke()] = () => direction -= Vector2.left,
                };

            if (actions.ContainsKey(pressedEvent.Key))
                actions[pressedEvent.Key].Invoke();

            _move.Direction += direction;
        }
    }
}
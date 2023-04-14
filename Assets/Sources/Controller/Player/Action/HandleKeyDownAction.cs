using System;
using System.Collections.Generic;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Input.Event;
using UnityEngine;

namespace Assets.Sources.Controller.Player.Action
{
    public class HandleKeyDownAction : IControllerAction<KeyDownEvent>
    {
        private readonly PlayerService _playerService;
        private readonly InputSetting _inputSetting;

        public HandleKeyDownAction(PlayerService playerService, InputSetting inputSetting)
        {
            _playerService = playerService;
            _inputSetting = inputSetting;
        }

        public void Handle(KeyDownEvent @event, IDispatcher dispatcher)
        {
            Dictionary<KeyCode, Action<PlayerService>> actions =
                new Dictionary<KeyCode, Action<PlayerService>>()
                {
                    [_inputSetting.SelectNextPlayer.Invoke()] = playerService => playerService.SelectNext(),
                    [_inputSetting.SelectPrevPlayer.Invoke()] = playerService => playerService.SelectPrev(),
                };

            if (actions.ContainsKey(@event.Key))
                actions[@event.Key].Invoke(_playerService);
        }
    }
}
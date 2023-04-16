using Assets.Sources.Common;
using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Action;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.PlayerSources.Presentation.Presenter;
using Assets.Sources.PlayerSources.Services;
using Assets.Sources.Presentation.View;
using Assets.Sources.Settings;
using UnityEngine;

namespace Assets.Sources.Controller.Player
{
    public class PlayerController : AbstractController, IUpdatable
    {
        private readonly PlayerService _playerService;
        private readonly Move _move = new Move();
        private readonly IDispatcher _dispatcher;

        private PlayerScoreViewAdapter _playerScoreViewAdapter;
    
        public PlayerController(IDispatcher dispatcher, InputSetting inputSetting) : base(dispatcher)
        {
            _dispatcher = dispatcher;
            _playerService = new PlayerService();
            _playerService.PlayerChanged += OnPlayerChanged;
            Register(new HandleKeyAction(inputSetting, _move));
            Register(new HandleKeyDownAction(_playerService, inputSetting));
            Register(new GameStartedPlayerAction(_playerService));
        }

        public override void Dispose()
        {
            _playerService.PlayerChanged -= OnPlayerChanged;
        }

        public void Update()
        {
            _playerService.Move(_move.Direction.normalized);
            _move.Direction = Vector3.zero;
        }

        private void OnPlayerChanged(PlayerPresenter player)
        {
            _dispatcher.Dispatch(new PlayerChangedEvent(player));
        }
    }
}
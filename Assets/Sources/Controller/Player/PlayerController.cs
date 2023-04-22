using Assets.Sources.Common;
using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Action;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.PlayerSources.Presentation.Presenter;
using Assets.Sources.PlayerSources.Services;
using Assets.Sources.Presentation.View;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using UnityEngine;

namespace Assets.Sources.Controller.Player
{
    public class PlayerController : AbstractController, IUpdatable
    {
        private readonly PlayerService _playerService;
        private readonly MovementService _movementService;

        private PlayerScoreViewAdapter _playerScoreViewAdapter;
    
        public PlayerController(IDispatcher dispatcher, InputSetting inputSetting) : base(dispatcher)
        {
            _movementService = new MovementService();
            _playerService = new PlayerService(_movementService);
            
            Register(new HandleKeyAction(inputSetting, _movementService));
            Register(new HandleKeyDownAction(_playerService, inputSetting));
            Register(new GameStartedPlayerAction(_playerService));
            Register(new SpawnPlayerAction(_playerService));

            AttachPlayerService();
        }

        public override void Dispose()
        {
            DetachPlayerService();
        }

        public void Update()
        {
            _playerService.Move();
        }

        private void OnPlayerChanged(PlayerPresenter player)
        {
            Dispatcher.Dispatch(new PlayerChangedEvent(player));
        }

        private void AttachPlayerService()
        {
            _playerService.PlayerChanged += OnPlayerChanged;
        }

        private void DetachPlayerService()
        {
            _playerService.PlayerChanged -= OnPlayerChanged;
        }
    }
}
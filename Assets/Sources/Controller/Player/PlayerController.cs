using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Action;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using DefaultNamespace;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Controller.Player
{
    public class PlayerController : AbstractController, IUpdatable
    {
        private readonly PlayerService _playerService;
        private readonly Move _move = new Move();
        private readonly IDispatcher _dispatcher;
    
        public PlayerController(IDispatcher dispatcher, InputSetting inputSetting) : base(dispatcher)
        {
            _dispatcher = dispatcher;
            _playerService = new PlayerService();
            _playerService.PlayerChanged += OnPlayerChanged;
            Register(new HandleKeyAction(inputSetting, _move));
            Register(new HandleKeyDownAction(_playerService, inputSetting));
            Register(new SpawnPlayerAction(_playerService));
    //        Register(new HandleKeyUpAction(_playerService, inputSetting));
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
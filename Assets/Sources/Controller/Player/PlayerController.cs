using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Action;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Controller.Player
{
    public class PlayerController : AbstractController, IUpdatable
    {
        private readonly PlayerService _playerService;
        private readonly Move _move = new Move();
    
        public PlayerController(IDispatcher dispatcher, InputSetting inputSetting) : base(dispatcher)
        {
            _playerService = new PlayerService(4);
            Register(new HandleKeyAction(inputSetting, _move));
            Register(new HandleKeyDownAction(_playerService, inputSetting));
    //        Register(new HandleKeyUpAction(_playerService, inputSetting));
        }

        public override void Dispose()
        {
        }

        public void Update()
        {
            _playerService.Move(_move.Direction.normalized);
            _move.Direction = Vector3.zero;
        }
    }
}
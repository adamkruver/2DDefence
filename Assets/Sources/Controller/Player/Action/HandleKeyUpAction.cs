using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Input.Event.Handle;

namespace Assets.Sources.Controller.Player.Action
{
    public class HandleKeyUpAction : IControllerAction<KeyUpEvent>
    {
        private readonly PlayerService _playerService;

        public HandleKeyUpAction(PlayerService playerService, InputSetting inputSetting)
        {
            _playerService = playerService;
        }

        public void Handle(KeyUpEvent @event, IDispatcher dispatcher)
        {
    //        _playerService.Move(Vector2.zero);
        }
    }
}
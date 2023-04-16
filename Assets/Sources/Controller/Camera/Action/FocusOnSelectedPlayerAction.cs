using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.PlayerSources.Presentation.Presenter;
using Assets.Sources.Services;
using DefaultNamespace;

namespace UnityEngine.Action
{
    public class FocusOnSelectedPlayerAction : IControllerAction<PlayerChangedEvent>
    {
        private readonly CameraService _cameraService;

        public FocusOnSelectedPlayerAction(CameraService _cameraService)
        {
            this._cameraService = _cameraService;
        }

        public void Handle(PlayerChangedEvent @event, IDispatcher dispatcher)
        {
            PlayerPresenter playerPresenter = @event.Player;
            _cameraService.Follow(playerPresenter);
        }
    }
}
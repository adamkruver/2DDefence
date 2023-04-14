using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Services;

namespace Assets.Sources.Controller.Input.Action
{
    public class DisableInputAction: IControllerAction<DisableInputEvent>
    {
        private readonly InputService _inputService;

        public DisableInputAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public void Handle(DisableInputEvent @event, IDispatcher dispatcher)
        {
            _inputService.Disable();
        }
    }
}
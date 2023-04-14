using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Services;
using UnityEngine;

namespace Assets.Sources.Controller.Input.Action
{
    public class EnableInputAction:IControllerAction<EnableInputEvent>
    {
        private readonly InputService _inputService;

        public EnableInputAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public void Handle(EnableInputEvent @event, IDispatcher dispatcher)
        {
            _inputService.Enable();
        }
    }
}
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Settings;
using Sources.Controller.Input.Event;
using Sources.Controller.Input.Event.Handle;

namespace Assets.Sources.Controller.Input.Action
{
    public class HandleKeyUpInputAction : IControllerAction<KeyUpInputEvent>
    {
        private readonly InputSetting _inputSetting;

        public HandleKeyUpInputAction(InputSetting inputSetting)
        {
            _inputSetting = inputSetting;
        }

        public void Handle(KeyUpInputEvent @event, IDispatcher dispatcher)
        {
            if (@event.IsInputEnabled)
                dispatcher.Dispatch(new KeyUpEvent(@event.Key));
        }
    }
}
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;

namespace Assets.Sources.Controller.Level.Action
{
    public class ExitAction: IControllerAction<ExitEvent>
    {
        private readonly LevelController _levelController;

        public ExitAction(LevelController levelController)
        {
            _levelController = levelController;
        }

        public void Handle(ExitEvent @event, IDispatcher dispatcher)
        {
            _levelController.Stop();
        }
    }
}
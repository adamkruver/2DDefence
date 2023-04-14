using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;

namespace Assets.Sources.Controller.Level.Action
{
    public class StartLevelAction : IControllerAction<StartLevelEvent>
    {
        private readonly LevelController _levelController;

        public StartLevelAction(LevelController levelController)
        {
            _levelController = levelController;
        }

        public void Handle(StartLevelEvent @event, IDispatcher dispatcher)
        {
            _levelController.Start();
        }
    }
}
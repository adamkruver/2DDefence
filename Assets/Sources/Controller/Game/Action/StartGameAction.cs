using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player.Event;

namespace Assets.Sources.Controller.Level.Action
{
    public class StartGameAction : IControllerAction<StartGameEvent>
    {
        private readonly GameController _gameController;

        public StartGameAction(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Handle(StartGameEvent @event, IDispatcher dispatcher)
        {
            _gameController.Start();
     //       dispatcher.Dispatch(new SpawnPlayerEvent(2));
        }
    }
}
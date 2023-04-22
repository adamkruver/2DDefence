using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;
using Sources.Controller.Scene.Event;

namespace Assets.Sources.Controller.Level.Action
{
    public class StartGameAction : IControllerAction<StartGameEvent>
    {
        private readonly GameController _gameController;
        private readonly ViewService _viewService;

        public StartGameAction(GameController gameController, ViewService viewService)
        {
            _gameController = gameController;
            _viewService = viewService;
        }

        public void Handle(StartGameEvent @event, IDispatcher dispatcher)
        {
            GameService gameService = _gameController.CreateGameService();
            dispatcher.Dispatch(new GameStartedEvent(gameService.TreasureProvider, @event.Players));

        }
    }
}
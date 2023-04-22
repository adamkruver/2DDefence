using Assets.Sources.Common;
using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Action;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Services;

namespace Assets.Sources.Controller.Level
{
    public class GameController : AbstractController, IUpdatable
    {
        private GameService _gameService;
        private ViewService _viewService = new ViewService();

        public GameController(IDispatcher dispatcher) : base(dispatcher)
        {
            Register(new ExitAction(this));
            Register(new StartGameAction(this, _viewService));
        }

        public override void Dispose()
        {
            _gameService?.Dispose();
        }

        public GameService CreateGameService()
        {
            _gameService?.Dispose();
            _gameService = new GameService(_viewService);
            _gameService.Enable();

            return _gameService;
        }

        public void Start()
        {
        }

        public void Update()
        {
            _gameService.Update();
        }
    }
}
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
        private IDispatcher _dispatcher;
        private GameService _gameService;
        private ViewService _viewService = new ViewService();

        public GameController(IDispatcher dispatcher) : base(dispatcher)
        {
            _dispatcher = dispatcher;
            Register(new ExitAction(this));
            Register(new StartGameAction(this));
        }

        public override void Dispose()
        {
            _gameService?.Dispose();
        }

        public void Start()
        {
            Dispose();
            _gameService = new GameService(_viewService);
            _gameService.Enable();
            _dispatcher.Dispatch(new GameStartedEvent(_gameService.TreasureProvider));
        }

        public void Update()
        {
            _gameService.Update();
        }
    }
}
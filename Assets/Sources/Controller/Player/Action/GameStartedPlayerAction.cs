using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.PlayerSources.Services;

namespace Assets.Sources.Controller.Player.Action
{
    public class GameStartedPlayerAction : IControllerAction<GameStartedEvent>
    {
        private readonly PlayerService _playerService;

        public GameStartedPlayerAction(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Handle(GameStartedEvent @event, IDispatcher dispatcher)
        {
            _playerService.Clear();

            for (int i = 0; i < 2; i++)
            {
                _playerService.CreatePlayer(i, @event.TreasureProvider);
            }

            _playerService.SelectNext();
        }
    }
}
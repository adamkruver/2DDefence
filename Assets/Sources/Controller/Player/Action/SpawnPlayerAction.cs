using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;

namespace Assets.Sources.Controller.Player.Action
{
    public class SpawnPlayerAction : IControllerAction<SpawnPlayerEvent>
    {
        private readonly PlayerService _playerService;

        public SpawnPlayerAction(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Handle(SpawnPlayerEvent @event, IDispatcher dispatcher)
        {
            _playerService.Clear();

            for (int i = 0; i < @event.Count; i++)
            {
                _playerService.CreatePlayer(i);
            }
            
            _playerService.SelectNext();
        }
    }
}
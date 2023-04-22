using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.PlayerSources.Services;
using UnityEngine;

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
            _playerService.SetTreasureProvider(@event.TreasureProvider);
            dispatcher.Dispatch(new SpawnPlayerEvent(@event.Players));
        }
    }
}
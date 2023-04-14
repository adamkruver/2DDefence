using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;

namespace Assets.Sources.Controller.Level.Action
{
    public class StartLevelAction : IControllerAction<StartLevelEvent>
    {
        private readonly LevelController _levelController;
        private readonly SpiderSpawnService _spiderSpawnService;

        public StartLevelAction(LevelController levelController, SpiderSpawnService spiderSpawnService)
        {
            _levelController = levelController;
            _spiderSpawnService = spiderSpawnService;
        }

        public void Handle(StartLevelEvent @event, IDispatcher dispatcher)
        {
            _spiderSpawnService.Enable();
            dispatcher.Dispatch(new SpawnPlayerEvent(2));
        }
    }
}
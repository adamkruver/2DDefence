using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Action;
using Assets.Sources.Services;
using Sources.Bootstrap;

namespace Assets.Sources.Controller.Level
{
    public class LevelController : AbstractController, IUpdatable
    {
        private readonly SpiderSpawnService _spiderSpawnService;

        public LevelController(IDispatcher dispatcher) : base(dispatcher)
        {
            _spiderSpawnService = new SpiderSpawnService();
            Register(new ExitAction(this));
            Register(new StartLevelAction(this, _spiderSpawnService));
        }

        public override void Dispose()
        {
        }

        public void Update()
        {
            _spiderSpawnService.Update();
        }
    }
}
using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Action;
using Assets.Sources.Services;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Controller.Level
{
    public class LevelController : AbstractController, IUpdatable
    {
        private SpiderSpawnService _spiderSpawnService = new SpiderSpawnService();

        public LevelController(IDispatcher dispatcher) : base(dispatcher)
        {
            Register(new ExitAction(this));
            Register(new StartLevelAction(this));
        }

        public void Start()
        {
            _spiderSpawnService.Enable();
        }
        
        public void Stop()
        {
            Application.Quit();
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
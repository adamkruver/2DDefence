using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Scene.Action;

namespace Sources.Controller.Scene
{
    public class SceneController : AbstractController
    {
        private readonly InputSetting _inputSetting;
        private readonly ViewService _viewService;

        public SceneController(IDispatcher dispatcher, IDispatcherControllerRegistrable registrator) : base(dispatcher)
        {
            registrator.Register(this);

            _viewService = new ViewService();
            _inputSetting = new InputSetting();

            Register(new RouteSceneAction());
            Register(new LoadBootstrapSceneAction());
            Register(new LoadSceneAction(registrator, this, _viewService));
            Register(new LoadDreamForestSceneAction(registrator, this, _inputSetting, _viewService));
            Register(new LoadMainGameMenuAction(registrator, this, _viewService));
            //         new InputController(dispatcher, inputSetting);
            //     new PlayerController(dispatcher, inputSetting);
            //   new CameraController(dispatcher);
        }

        public override void Dispose()
        {
        }
    }
}
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Controller.Level;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player;
using Assets.Sources.Controller.Player.Event;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Scene.Event;
using UnityEngine;

namespace Sources.Controller.Scene.Action
{
    public class LoadDreamForestSceneAction : AbstractSceneAction<LoadDreamForestSceneEvent>
    {
        private readonly InputSetting _inputSetting;

        public LoadDreamForestSceneAction(
            IDispatcherControllerRegistrable registrator,
            SceneController sceneController,
            InputSetting inputSetting,
            ViewService viewService
        ):
        base(registrator, sceneController, viewService)
        {
            _inputSetting = inputSetting;
        }
        
        public override void Handle(LoadDreamForestSceneEvent @event, IDispatcher dispatcher)
        {
            Registrator.Register(new InputController(dispatcher, _inputSetting));
            Registrator.Register(new PlayerController(dispatcher, _inputSetting));
            Registrator.Register(new GameController(dispatcher));
            Registrator.Register(new CameraController(dispatcher));
            
            dispatcher.Dispatch(new EnableInputEvent());
            dispatcher.Dispatch(new StartGameEvent(3));
            
            ViewService.HideCurtain();
        }
    }
}
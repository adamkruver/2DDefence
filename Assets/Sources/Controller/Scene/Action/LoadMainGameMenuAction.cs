using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Sources.Controller.Scene.Event;
using Sources.Controller.View;
using Sources.Controller.View.Event;

namespace Sources.Controller.Scene.Action
{
    public class LoadMainGameMenuAction : AbstractSceneAction<LoadMainGameMenuEvent>
    {
        public LoadMainGameMenuAction(
            IDispatcherControllerRegistrable registrator,
            SceneController sceneController,
            ViewService viewService
        ) :
            base(registrator, sceneController, viewService)
        {
        }

        public override void Handle(LoadMainGameMenuEvent @event, IDispatcher dispatcher)
        {
            ViewService.HideCurtain();
            Registrator.Register(new ViewController(dispatcher, ViewService));
            
            dispatcher.Dispatch(new ShowMainGameMenuEvent());
        }
    }
}
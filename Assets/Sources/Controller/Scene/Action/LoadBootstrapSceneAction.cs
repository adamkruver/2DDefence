using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Sources.Controller.Scene.Event;

namespace Sources.Controller.Scene.Action
{
    public class LoadBootstrapSceneAction : IControllerAction<LoadBootstrapEvent>
    {
        public void Handle(LoadBootstrapEvent @event, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new LoadSceneEvent("Scenes/GameMenu"));
        }
    }
}
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;

namespace Sources.Controller.Scene.Action
{
    public abstract class AbstractSceneAction<T> : IControllerAction<T> where T : IControllerEvent
    {
        protected readonly IDispatcherControllerRegistrable Registrator;
        protected readonly SceneController SceneController;
        protected readonly ViewService ViewService;

        public AbstractSceneAction(
            IDispatcherControllerRegistrable registrator,
            SceneController sceneController,
            ViewService viewService
        )
        {
            Registrator = registrator;
            SceneController = sceneController;
            ViewService = viewService;
        }

        public abstract void Handle(T @event, IDispatcher dispatcher);
    }
}
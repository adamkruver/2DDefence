using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Scene.Event;
using UnityEngine.SceneManagement;

namespace Sources.Controller.Scene.Action
{
    public class LoadSceneAction : IControllerAction<LoadSceneEvent>
    {
        private readonly IDispatcherControllerRegistrable _registrator;
        private readonly SceneController _sceneController;
        private readonly ViewService _viewService;

        public LoadSceneAction(
            IDispatcherControllerRegistrable registrator,
            SceneController sceneController,
            ViewService viewService
        )
        {
            _registrator = registrator;
            _sceneController = sceneController;
            _viewService = viewService;
        }

        public void Handle(LoadSceneEvent @event, IDispatcher dispatcher)
        {
            _registrator.UnregisterAll();

            _viewService.Disable();
            _viewService.Enable();
            _viewService.ShowCurtain();

            _registrator.Register(_sceneController);

            SceneManager.LoadScene(@event.SceneName);
        }
    }
}
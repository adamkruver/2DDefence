using Assets.Sources.Common.MVC.Dispatcher;
using Sources.Controller.Scene;
using Sources.Controller.Scene.Event;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.GameBuilder
{
    public class GameBuilder : MonoBehaviour
    {
        private readonly Dispatcher _dispatcher = new Dispatcher();
        private SceneController _sceneController;

        private void Awake()
        {
            _sceneController = new SceneController(_dispatcher, _dispatcher);

            DontDestroyOnLoad(gameObject);
        }

        private void Start() =>
            _dispatcher.Dispatch(new LoadSceneEvent("Scenes/Bootstrap"));

        private void Update() =>
            _dispatcher.Update();

        private void OnDestroy() =>
            _dispatcher.Dispose();

        public void OnSceneLoaded()
        {
            _dispatcher.Dispatch(new SceneLoadedEvent(SceneManager.GetActiveScene().name));
        }
    }
}
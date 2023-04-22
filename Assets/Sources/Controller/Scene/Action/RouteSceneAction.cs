using System.Collections.Generic;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Sources.Controller.Scene.Event;
using Sources.Exception;

namespace Sources.Controller.Scene.Action
{
    public class RouteSceneAction : IControllerAction<SceneLoadedEvent>
    {
        public void Handle(SceneLoadedEvent @event, IDispatcher dispatcher)
        {
            Dictionary<string, System.Action> _sceneLoaders = new Dictionary<string, System.Action>()
            {
                ["Bootstrap"] = () => dispatcher.Dispatch(new LoadBootstrapEvent()),
                ["GameMenu"] = () => dispatcher.Dispatch(new LoadMainGameMenuEvent()),
                ["DreamForestLevel"] = () => dispatcher.Dispatch(new LoadDreamForestSceneEvent()),
            };

            string sceneName = @event.SceneName;

            if (_sceneLoaders.ContainsKey(sceneName) == false)
                throw new SceneNotFoundException(sceneName);

            _sceneLoaders[sceneName].Invoke();
        }
    }
}
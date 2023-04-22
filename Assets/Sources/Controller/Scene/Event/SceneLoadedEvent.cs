using Assets.Sources.Common.MVC;

namespace Sources.Controller.Scene.Event
{
    public class SceneLoadedEvent: IControllerEvent
    {
        public SceneLoadedEvent(string sceneName)
        {
            SceneName = sceneName;
        }
        
        public string SceneName { get; }
    }
}
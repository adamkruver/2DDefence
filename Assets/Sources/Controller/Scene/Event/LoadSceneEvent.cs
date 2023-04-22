using Assets.Sources.Common.MVC;

namespace Sources.Controller.Scene.Event
{
    public class LoadSceneEvent : IControllerEvent
    {
        public LoadSceneEvent(string sceneName)
        {
            SceneName = sceneName;
        }
        
        public string SceneName { get; }
    }
}
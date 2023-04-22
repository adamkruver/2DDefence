namespace Sources.Exception
{
    public class SceneNotFoundException: System.Exception
    {
        public SceneNotFoundException(string sceneName) : base($"Scene {sceneName} not found in router Dictionary")
        {
        }
    }
}
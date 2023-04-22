using Assets.Sources.Common.MVC;

namespace Assets.Sources.Controller.Player.Event
{
    public class SpawnPlayerEvent : IControllerEvent
    {
        public SpawnPlayerEvent(int playerCount)
        {
            PlayerCount = playerCount;
        }
        
        public int PlayerCount { get; }
    }
}
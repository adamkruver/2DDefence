using Assets.Sources.Common.MVC;

namespace Assets.Sources.Controller.Player.Event
{
    public class SpawnPlayerEvent : IControllerEvent
    {
        public SpawnPlayerEvent(int count)
        {
            Count = count;
        }
        
        public int Count { get; }
    }
}
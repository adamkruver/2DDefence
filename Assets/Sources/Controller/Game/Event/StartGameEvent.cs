using Assets.Sources.Common.MVC;

namespace Assets.Sources.Controller.Level.Event
{
    public class StartGameEvent : IControllerEvent
    {
        public StartGameEvent(int players)
        {
            Players = players;
        }

        public int Players { get; }
    }
}
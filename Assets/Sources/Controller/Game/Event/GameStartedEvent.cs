using Assets.Sources.Common.MVC;
using Assets.Sources.Presentation.Presenter;

namespace Assets.Sources.Controller.Level.Event
{
    public class GameStartedEvent : IControllerMulticastEvent
    {
        public GameStartedEvent(TreasureProvider treasureProvider, int players)
        {
            TreasureProvider = treasureProvider;
            Players = players;
        }

        public TreasureProvider TreasureProvider { get; }
        public int Players { get; }
    }
}
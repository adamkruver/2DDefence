using Assets.Sources.Common.MVC;
using Assets.Sources.Presentation.Presenter;

namespace Assets.Sources.Controller.Level.Event
{
    public class GameStartedEvent : IControllerMulticastEvent
    {
        public GameStartedEvent(TreasureProvider treasureProvider)
        {
            TreasureProvider = treasureProvider;
        }

        public TreasureProvider TreasureProvider { get; }
    }
}
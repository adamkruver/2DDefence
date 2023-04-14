using Assets.Sources.Common.MVC;
using DefaultNamespace;

namespace Assets.Sources.Controller.Player.Event
{
    public class PlayerChangedEvent : IControllerEvent
    {
        public PlayerChangedEvent(PlayerPresenter player)
        {
            Player = player;
        }
        
        public PlayerPresenter Player { get; }
    }
}
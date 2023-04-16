using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Level.Event;
using UnityEngine;

namespace Assets.Sources.Controller.Level.Action
{
    public class ExitAction: IControllerAction<ExitEvent>
    {
        private readonly GameController _gameController;

        public ExitAction(GameController gameController)
        {
            _gameController = gameController;
        }

        public void Handle(ExitEvent @event, IDispatcher dispatcher)
        {
            Application.Quit();
        }
    }
}
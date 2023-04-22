using Assets.Sources.Common.Factory;
using Assets.Sources.Common.MVC;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Sources.Controller.Scene.Event;
using Sources.Controller.View.Event;
using Sources.GameMenu.Presentation;

namespace Sources.Controller.View.Action
{
    public class ShowMainGameMenuAction: IControllerAction<ShowMainGameMenuEvent>
    {
        private readonly ViewService _viewService;

        public ShowMainGameMenuAction(ViewService viewService)
        {
            _viewService = viewService;
        }

        public void Handle(ShowMainGameMenuEvent @event, IDispatcher dispatcher)
        {
            GameMenuView gameMenuView = new Factory<GameMenuView>().Create();

            _viewService.Show(gameMenuView, new GameMenuPresenter(() =>
                dispatcher.Dispatch(new LoadSceneEvent("Scenes/DreamForestLevel"))));
        }
    }
}
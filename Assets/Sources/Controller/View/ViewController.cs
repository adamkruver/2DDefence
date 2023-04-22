using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using Sources.Controller.View.Action;

namespace Sources.Controller.View
{
    public class ViewController : AbstractController
    {
        private readonly ViewService _viewService;

        public ViewController(IDispatcher dispatcher, ViewService viewService) : base(dispatcher)
        {
            _viewService = viewService;
            
            Register(new ShowMainGameMenuAction(_viewService));
        }

        public override void Dispose()
        {
        }
    }
}
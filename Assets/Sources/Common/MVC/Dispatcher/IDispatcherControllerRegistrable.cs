using Assets.Sources.Common.MVC.Controller;

namespace Assets.Sources.Common.MVC.Dispatcher
{
    public interface IDispatcherControllerRegistrable
    {
        void Register(IController controller);
        void UnregisterAll();
    }
}
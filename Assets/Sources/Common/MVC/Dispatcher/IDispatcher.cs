using Assets.Sources.Common.MVC.Controller;

namespace Assets.Sources.Common.MVC.Dispatcher
{
    public interface IDispatcher
    {
        void Dispatch<T>(T @event) where T : IControllerEvent;
    }
}
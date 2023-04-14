using Assets.Sources.Common.MVC.Dispatcher;

namespace Assets.Sources.Common.MVC
{
    public interface IControllerAction
    {
    }

    public interface IControllerAction<T>: IControllerAction where T : IControllerEvent
    {
        void Handle(T @event, IDispatcher dispatcher);
    }
}
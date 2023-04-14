using System;

namespace Assets.Sources.Common.MVC.Controller
{
    public interface IController: IDisposable
    {
        bool ContainDispatcher(IControllerEvent @event);
        void Dispatch<T>(T @event) where T : IControllerEvent;
    }
}
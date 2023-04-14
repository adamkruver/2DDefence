using System;
using System.Collections.Generic;
using Assets.Sources.Common.MVC.Dispatcher;

namespace Assets.Sources.Common.MVC.Controller
{
    public abstract class AbstractController : IController
    {
        private readonly IDispatcher _dispatcher;
        private readonly Dictionary<Type, IControllerAction> _actions = new Dictionary<Type, IControllerAction>();

        protected AbstractController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
            dispatcher.Register(this);
        }

        public abstract void Dispose();

        public bool ContainDispatcher(IControllerEvent @event)
        {
            return _actions.ContainsKey(@event.GetType());
        }

        public void Dispatch<T>(T @event) where T : IControllerEvent
        {
            if (ContainDispatcher(@event) == false)
                return;

            IControllerAction<T> action = (IControllerAction<T>)_actions[typeof(T)];

            action.Handle(@event, _dispatcher);
        }

        public void Register<T>(IControllerAction<T> action) where T : IControllerEvent
        {
            if(_actions.ContainsKey(typeof(T)))
                return;

            _actions[typeof(T)] = action;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Sources.Common.MVC.Controller;
using UnityEngine;

namespace Assets.Sources.Common.MVC.Dispatcher
{
    public class Dispatcher : IDispatcher, IDispatcherControllerRegistrable, IDisposable, IUpdatable
    {
        private readonly List<IController> _controllers = new List<IController>();

        public void Register(IController controller)
        {
            if (_controllers.Contains(controller))
                return;

            _controllers.Add(controller);
        }

        public void Dispatch<T>(T @event) where T : IControllerEvent
        {
            foreach (IController controller in _controllers)
            {
                if (controller.ContainDispatcher(@event))
                {
                    controller.Dispatch(@event);

                    if (@event is not IControllerMulticastEvent)
                        return;
                }
            }

            // TODO : Not Found Controller Message;
        }

        public void Dispose()
        {
            foreach (IController controller in _controllers)
            {
                controller.Dispose();
            }
        }

        public void UnregisterAll()
        {
            Dispose();

            _controllers.Clear();
        }

        public void Update()
        {
            var controllers = _controllers
                .Where(controller => controller is IUpdatable)
                .Cast<IUpdatable>().ToList();

            foreach (IUpdatable controller in controllers)
            {
                controller.Update();
            }
        }
    }
}
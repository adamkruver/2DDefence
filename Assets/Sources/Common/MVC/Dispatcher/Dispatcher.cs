using System;
using System.Collections.Generic;
using Assets.Sources.Common.MVC.Controller;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Common.MVC.Dispatcher
{
    public class Dispatcher : IDispatcher, IDisposable, IUpdatable
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

        public void Update()
        {
            foreach (IController controller in _controllers)
            {
                if (controller is IUpdatable updatableController)
                {
                    updatableController.Update();
                }
            }
        }
    }
}
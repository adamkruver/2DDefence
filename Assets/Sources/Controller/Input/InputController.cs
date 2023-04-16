using Assets.Sources.Common;
using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input.Action;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Services;
using Assets.Sources.Settings;
using Sources.Controller.Input.Event;
using UnityEngine;

namespace Assets.Sources.Controller.Input
{
    public class InputController : AbstractController, IUpdatable
    {
        private readonly IDispatcher _dispatcher;
        private readonly InputService _inputService;

        public InputController(IDispatcher dispatcher, InputSetting inputSetting) : base(dispatcher)
        {
            _dispatcher = dispatcher;
            _inputService = new InputService(inputSetting);
            _inputService.KeyPressed += OnKeyPressed;
            _inputService.KeyDown += OnKeyDown;
            _inputService.KeyUp += OnKeyUp;
        
            Register(new EnableInputAction(_inputService));
            Register(new DisableInputAction(_inputService));
            Register(new HandleKeyInputAction(inputSetting));
            Register(new HandleKeyDownInputAction(inputSetting));
            Register(new HandleKeyUpInputAction(inputSetting));
        }

        private void OnKeyUp(KeyCode key)
        {
            _dispatcher.Dispatch(new KeyUpInputEvent(key, _inputService.IsEnabled));
        }

        private void OnKeyDown(KeyCode key)
        {
            _dispatcher.Dispatch(new KeyDownInputEvent(key, _inputService.IsEnabled));
        }

        private void OnKeyPressed(KeyCode key)
        {
            _dispatcher.Dispatch(new KeyPressedInputEvent(key, _inputService.IsEnabled));
        }

        public override void Dispose()
        {
            _inputService.KeyPressed -= OnKeyPressed;
            _inputService.KeyDown -= OnKeyDown;
            _inputService.KeyUp -= OnKeyUp;
        }

        public void Update()
        {
            _inputService.Update();
        }
    }
}
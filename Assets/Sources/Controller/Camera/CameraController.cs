using Assets.Sources.Common.MVC.Controller;
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Services;
using UnityEngine.Action;

namespace UnityEngine
{
    public class CameraController : AbstractController
    {
        private readonly CameraService _cameraService;

        public CameraController(IDispatcher dispatcher) : base(dispatcher)
        {
            _cameraService = new CameraService();
            _cameraService.Enable();
            Register(new FocusOnSelectedPlayerAction(_cameraService));
        }

        public override void Dispose()
        {
            _cameraService.Dispose();
        }
    }
}
using Assets.Sources.Common.MVC.Dispatcher;
using Assets.Sources.Controller.Input;
using Assets.Sources.Controller.Input.Event;
using Assets.Sources.Controller.Level;
using Assets.Sources.Controller.Level.Event;
using Assets.Sources.Controller.Player;
using Assets.Sources.Settings;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private readonly Dispatcher _dispatcher = new Dispatcher();

    private void Awake()
    {
        InputSetting inputSetting = new InputSetting();

        new InputController(_dispatcher, inputSetting);
        new GameController(_dispatcher);
        new PlayerController(_dispatcher, inputSetting);
        new CameraController(_dispatcher);
    }

    private void Start() =>
        _dispatcher.Dispatch(new StartGameEvent());

    private void OnEnable() =>
        _dispatcher.Dispatch(new EnableInputEvent());

    private void OnDisable() =>
        _dispatcher.Dispatch(new DisableInputEvent());

    private void Update() =>
        _dispatcher.Update();

    private void OnDestroy() =>
        _dispatcher.Dispose();
}
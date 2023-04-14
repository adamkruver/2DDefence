using Assets.Sources.Services.State;

namespace Assets.Sources.Services
{
    public interface IStateChangableService: IService
    {
        void SetState(IServiceState state);
        void Initialize();
        void OnEnable();
        void OnDisable();
        void OnDispose();
    }
}
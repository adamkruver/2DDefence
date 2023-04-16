using Assets.Sources.Common.Service.State;

namespace Assets.Sources.Common.Service
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
namespace Assets.Sources.Common.Service.State
{
    public interface IServiceState
    {
        void Enable(IStateChangableService service);
        void Disable(IStateChangableService service);
        void Dispose(IStateChangableService service);
    }
}
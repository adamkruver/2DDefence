namespace Assets.Sources.Services.State
{
    public interface IServiceState
    {
        void Enable(IStateChangableService service);
        void Disable(IStateChangableService service);
        void Dispose(IStateChangableService service);
    }
}
namespace Assets.Sources.Common.Service.State
{
    public class EnableState : IServiceState
    {
        public void Enable(IStateChangableService service)
        {
        }

        public void Disable(IStateChangableService service)
        {
            service.SetState(new DisableState());
            service.OnDisable();
        }

        public void Dispose(IStateChangableService service)
        {
            service.SetState(new DisposeState());
            service.OnDispose();
        }
    }
}
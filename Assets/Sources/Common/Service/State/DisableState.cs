namespace Assets.Sources.Common.Service.State
{
    public class DisableState:IServiceState
    {
        public void Enable(IStateChangableService service)
        {
            service.SetState(new EnableState());
            service.OnEnable();
        }

        public void Disable(IStateChangableService service)
        {
        }

        public void Dispose(IStateChangableService service)
        {
            service.SetState(new DisposeState());
            service.OnDispose();
        }
    }
}
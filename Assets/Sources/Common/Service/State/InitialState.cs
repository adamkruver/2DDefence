namespace Assets.Sources.Common.Service.State
{
    public class InitialState: IServiceState
    {
        public void Enable(IStateChangableService service)
        {
            service.Initialize();
            service.SetState(new EnableState());
            service.OnEnable();
        }

        public void Disable(IStateChangableService service)
        {
        }

        public void Dispose(IStateChangableService service)
        {
        }
    }
}
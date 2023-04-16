using Assets.Sources.Common.Service.State;

namespace Assets.Sources.Common.Service
{
    public abstract class AbstractService : IStateChangableService
    {
        protected IServiceState State { get; private set; } = new InitialState();
        
        public void SetState(IServiceState state)
        {
            State = state;
        }

        public void Enable()
        {
            State.Enable(this);
        }

        public void Disable()
        {
            State.Disable(this);
        }

        public void Dispose()
        {
            State.Disable(this);
            State.Dispose(this);
        }

        public virtual void Initialize()
        {
        }

        public virtual void OnEnable()
        {
        }

        public virtual void OnDisable()
        {
        }

        public virtual void OnDispose()
        {
        }
    }
}
using Assets.Sources.Common.Service.State;

namespace Assets.Sources.Common.Service
{
    public abstract class UpdatableService : AbstractService, IUpdatable
    {
        public void Update()
        {
            if (State is EnableState)
                OnUpdate();
        }

        public abstract void OnUpdate();
    }
}
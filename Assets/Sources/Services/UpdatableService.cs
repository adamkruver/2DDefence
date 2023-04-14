using Assets.Sources.Services.State;
using Sources.Bootstrap;

namespace Assets.Sources.Services
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
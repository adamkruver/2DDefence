using Assets.Sources.Common.Targeting;
using Assets.Sources.Presentation.Presenter;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Presenter.Component
{
    public class PlayerTargetTracker : TargetTracker
    {
        private TreasureProvider _treasureProvider;

        public void Set(TreasureProvider treasureProvider)
        {
            _treasureProvider = treasureProvider;
        }
        
        public override Vector3 GetTrackPosition()
        {
            return _treasureProvider?.Transform.position ?? base.GetTrackPosition();
        }
    }
}
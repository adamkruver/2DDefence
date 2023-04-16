using Assets.Sources.Common.Service;
using Assets.Sources.PlayerSources.Presentation.Presenter;
using DefaultNamespace;
using UnityEngine;

namespace Assets.Sources.Services
{
    public class CameraService : AbstractService
    {
        private SelectedPlayerCameraFollower _selectedPlayerCameraFollower;

        public override void Initialize()
        {
            //TODO : Move to factory
            _selectedPlayerCameraFollower = Camera.main.GetComponent<SelectedPlayerCameraFollower>();
        }

        public void Follow(PlayerPresenter playerPresenter)
        {
            _selectedPlayerCameraFollower.Follow(playerPresenter);
        }
    }
}
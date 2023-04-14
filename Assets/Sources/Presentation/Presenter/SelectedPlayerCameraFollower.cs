using UnityEngine;

namespace DefaultNamespace
{
    public class SelectedPlayerCameraFollower : MonoBehaviour
    {
        [SerializeField] private float _followSpeed = 2f;
    
        private  PlayerPresenter _playerPresenter;

        public void Follow(PlayerPresenter playerPresenter)
        {
            _playerPresenter = playerPresenter;
        }

        public void LateUpdate()
        {
            if(_playerPresenter is null)
                return;
            
            Follow();
        }

        private void Follow()
        {
            Vector3 target = _playerPresenter.transform.position;
            target.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, target, _followSpeed * Time.deltaTime);
        }
    }
}
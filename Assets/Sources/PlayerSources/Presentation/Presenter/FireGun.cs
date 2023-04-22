using System;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Presenter
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FireGun: MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private bool _isFire = true;
        
        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Fire()
        {
            if (_isFire)
                return;
            
            _particleSystem.Play();
            _isFire = true;
        }

        public void Stop()
        {
            if(_isFire == false)
                return;
            
            _particleSystem.Stop();
            _isFire = false;
        }
    }
}
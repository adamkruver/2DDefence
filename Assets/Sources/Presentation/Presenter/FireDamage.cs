using System.Collections.Generic;
using Assets.Sources.Enemy.SpiderSources.Presentation.Presenter;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FireDamage : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        private List<ParticleCollisionEvent> _collisionEvents;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _collisionEvents = new List<ParticleCollisionEvent>();
        }

        private void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = _particleSystem.GetCollisionEvents(other, _collisionEvents);

            if (other.TryGetComponent(out SpiderPresenter spider))
            {
                spider.TakeDamage(20);
            }
        }
    }
}
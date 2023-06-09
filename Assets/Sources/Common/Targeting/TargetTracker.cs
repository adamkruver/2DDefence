﻿using Assets.Sources.PlayerSources.Presentation.Presenter.Component;
using Assets.Sources.Presentation.Presenter;
using UnityEngine;

namespace Assets.Sources.Common.Targeting
{
    public class TargetTracker : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleCollider2D;
        [SerializeField] private int _maxEnemies = 50;
        [SerializeField] private LayerMask _targetLayerMask;
        [SerializeField] private LayerMask _rayCastLayerMask;

        private Vector3 _aggroPosition;
        private float _aggroRadius;
        private Collider2D[] _targets;

        public Transform Target { get; private set; }

        private void Awake()
        {
            _aggroRadius = _circleCollider2D.radius;
            _circleCollider2D.gameObject.SetActive(false);
            _targets = new Collider2D[_maxEnemies];
        }

        private void Update()
        {
            _aggroPosition = _circleCollider2D.transform.position;

            int targets = Physics2D.OverlapCircleNonAlloc(_aggroPosition, _aggroRadius, _targets, _targetLayerMask);

            if (targets == 0)
            {
                Target = null;
                return;
            }

            SelectClosestTarget(targets, GetTrackPosition());
        }

        public virtual Vector3 GetTrackPosition()
        {
            return transform.position;
        }

        private void SelectClosestTarget(int targetCount, Vector3 position)
        {
            float minDistance = float.MaxValue;
            ContactFilter2D contactFilter2D = new ContactFilter2D();
            RaycastHit2D[] raycastHits2D = new RaycastHit2D[1];
            contactFilter2D.SetLayerMask(_rayCastLayerMask);
            Target = null;

            for (int i = 0; i < targetCount; i++)
            {
                Collider2D target = _targets[i];
                int hits = Physics2D.Raycast(_aggroPosition, target.transform.position - _aggroPosition, contactFilter2D, raycastHits2D);
                
                if(hits == 0 || raycastHits2D[0].collider != target)
                    continue;
                
                float distance = Vector3.Distance(position, target.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    Target = target.transform;
                }
            }
        }
    }
}
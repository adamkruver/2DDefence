using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TargetTracker : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _circleCollider2D;
        [SerializeField] private int _maxEnemies = 50;

        private int _layerMask;
        private Vector3 _aggroPosition;
        private float _aggroRadius;
        private Collider2D[] _targets;
        
        public Transform Target { get; private set; }
        
        private void Awake()
        {
            _aggroRadius = _circleCollider2D.radius;
            _circleCollider2D.gameObject.SetActive(false);
            _targets = new Collider2D[_maxEnemies];
            _layerMask = 1 << LayerMask.NameToLayer("Enemies");
        }

        private void Update()
        {
            _aggroPosition = _circleCollider2D.transform.position;
        
            int targets = Physics2D.OverlapCircleNonAlloc(_aggroPosition, _aggroRadius, _targets, _layerMask);

            if (targets == 0)
            {
                Target = null;
                return;
            }
            
            Target = _targets[0].transform;
        }
    }
}
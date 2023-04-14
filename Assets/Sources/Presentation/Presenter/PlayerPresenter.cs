using System;
using Assets.Sources.Domain;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 6f;
        [SerializeField] private GameObject _frame;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private Player _player;
        private Vector3 _velocity = Vector3.zero;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _velocity * Time.fixedDeltaTime;
        }

        public void Construct(Player player)
        {
            _player = player;
        }

        public void SetSelected(Player player)
        {
            bool isActive = player == _player;
            _frame.gameObject.SetActive(isActive);
        }

        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void Move(Vector2 direction)
        {
            Debug.Log(direction);
            _velocity = (Vector3)direction * _playerSpeed;
        }
    }
}
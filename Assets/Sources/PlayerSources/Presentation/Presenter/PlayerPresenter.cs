using Assets.Sources.PlayerSources.Domain;
using Assets.Sources.PlayerSources.Presentation.Presenter.Component;
using Assets.Sources.Presentation.Presenter;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Presenter
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 6f;
        [SerializeField] private GameObject _frame;
        [SerializeField] private PlayerTargetTracker _targetTracker;
        
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

        public void Construct(Player player, TreasureProvider treasureProvider)
        {
            _player = player;
            _targetTracker.Set(treasureProvider);
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
            _velocity = (Vector3)direction * _playerSpeed;
        }
    }
}
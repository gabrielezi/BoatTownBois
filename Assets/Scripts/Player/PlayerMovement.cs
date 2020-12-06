using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 0.05f;

        private Vector3 _targetPosition;
        private bool _moving;
        private Camera _camera;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        private int _animatorMoving;

        private void Start()
        {
            _animatorMoving = Animator.StringToHash("moving");
            _camera = Camera.main;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (
                (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                && CharacterSelect.Instance.IsCharacterSelected(gameObject)
                )
            {
                _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                _targetPosition += (Random.insideUnitSphere * 0.5f);
                _targetPosition.z = transform.position.z;

                var direction = _targetPosition - transform.position;
                _spriteRenderer.flipX = direction.x < 0;
            
                _moving = true;
                _animator.SetBool(_animatorMoving, true);
            }
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }

        private void FixedUpdate()
        {
            if (_moving)
            {
                SoundManager.Instance.PlaySound("Bleep");
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _targetPosition,
                    speed
                );
                if (transform.position == _targetPosition)
                {
                    _moving = false;
                    _animator.SetBool(_animatorMoving, false);
                }
            }
        }
    }
}
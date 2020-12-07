using Fight.Damage;
using UnityEngine;

namespace Enemy
{
    public class ReactiveEnemyAI : MonoBehaviour
    {
        [SerializeField] private float detectionRange = 5f;
        [SerializeField] private float chaseSpeed = 0.02f;
        [SerializeField] private float patrolSpeed = 0.02f;
        [SerializeField] private int patrolRange = 100;
        [SerializeField] private int idleTime = 100;
        [SerializeField] private int attackDamage = 5;

        private bool _chaseTarget;
        private int _patrolCount;
        private int _idleCount;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;

        private Player.Player _target;
        private float _attackRate = 1f;
        private float _nextAttackTime = 0f;

        private int _animatorMoving;
        private int _animatorAttack;

        private void Start()
        {
            _animatorMoving = Animator.StringToHash("moving");
            _animatorAttack = Animator.StringToHash("attack");
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _animator = gameObject.GetComponent<Animator>();

            InvokeRepeating(nameof(FindClosestPlayerCharacter), 0, 3f);
        }

        private void FindClosestPlayerCharacter()
        {
            Player.Player[] characters = FindObjectsOfType<Player.Player>();

            Player.Player closestPlayerCharacter = null;
            float distanceToClosestPlayerCharacter = float.MaxValue;

            foreach (var character in characters)
            {
                float distance = Vector2.Distance(transform.position, character.transform.position);
                if (distance < distanceToClosestPlayerCharacter)
                {
                    closestPlayerCharacter = character;
                    distanceToClosestPlayerCharacter = distance;
                }
            }

            _target = closestPlayerCharacter;
        }

        private void FixedUpdate()
        {
            if (_target == null)
            {
                _animator.SetBool(_animatorMoving, false);

                return;
            }

            var position = transform.position;
            var targetPosition = _target.transform.position;

            var direction = targetPosition - position;

            var distance = Vector2.Distance(position, targetPosition);
            _chaseTarget = distance < detectionRange;

            if (distance < 0.75f)
            {
                if (Time.time >= _nextAttackTime)
                {
                    _nextAttackTime = Time.time + 1f / _attackRate;
                    _animator.SetTrigger(_animatorAttack);
                    SoundManager.Instance.PlaySound("Hit");
                    _target.GetComponent<IDamageable>().TakeDamage(attackDamage);
                }

                return;
            }

            if (_chaseTarget)
            {
                _spriteRenderer.flipX = direction.x >= 0;
                position = Vector2.MoveTowards(
                    position,
                    targetPosition,
                    chaseSpeed
                );
                _animator.SetBool(_animatorMoving, true);
                SoundManager.Instance.PlaySound("Green Run");
            }
            else if (_idleCount > 0)
            {
                _animator.SetBool(_animatorMoving, false);
                _idleCount--;
            }
            else
            {
                _spriteRenderer.flipX = patrolSpeed >= 0;
                if (_patrolCount >= patrolRange)
                {
                    patrolSpeed *= -1;
                    _patrolCount = 0;
                    _idleCount = idleTime;
                }

                position += transform.right * patrolSpeed;
                _patrolCount++;
                _animator.SetBool(_animatorMoving, true);
                SoundManager.Instance.PlaySound("Green Run");
            }

            transform.position = position;
        }
    }
}

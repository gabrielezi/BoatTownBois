using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class ReactiveEnemyAI : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float detectionRange = 5f;
        [SerializeField]
        private float chaseSpeed = 0.02f;
        [SerializeField]
        private float patrolSpeed = 0.02f;
        [SerializeField]
        private int patrolRange = 100;
        [SerializeField]
        private int idleTime = 100;

        private bool _chaseTarget;
        private int _patrolCount;
        private int _idleCount;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        
        private int _animatorMoving;
        private int _animatorAttacking;

        private void Start()
        {
            _animatorMoving = Animator.StringToHash("moving");
            _animatorAttacking = Animator.StringToHash("attacking");
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _spriteRenderer.sortingOrder = Random.Range(0, int.MaxValue);
            _animator = gameObject.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            var position = transform.position;
            var targetPosition = target.position;

            var direction = targetPosition - position;
            
            var distance = Vector2.Distance(position, targetPosition);
            _chaseTarget = distance < detectionRange;

            if (distance < 0.75f)
            {
                _animator.SetBool(_animatorAttacking, true);
                SoundManager.Instance.PlaySound("Hit");

                return;
            }
            if (distance > 1.5f)
            {
                _animator.SetBool(_animatorAttacking, false);
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

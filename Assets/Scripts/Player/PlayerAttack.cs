using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private int attackTimer = 50;
        
        private Animator _animator;
        private bool _attacking;
        
        private int _animatorAttacking;
        private int _attackCount;
    
        private void Start()
        {
            _animatorAttacking = Animator.StringToHash("attacking");
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _attackCount = attackTimer;
            }
        }

        private void FixedUpdate()
        {
            if (_attackCount > 0)
            {
                _attackCount--;
                _animator.SetBool(_animatorAttacking, true);
                SoundManager.Instance.PlaySound("Explosion");
            }
            else
            {
                _animator.SetBool(_animatorAttacking, false);
            }
        }
    }
}
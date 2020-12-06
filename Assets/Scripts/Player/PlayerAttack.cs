using Fight.Damage;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layer;
        [SerializeField]
        private float attackRange = 0.5f;
        [SerializeField]
        private int attackDamage = 20;


        private float _attackRate = 1f;
        private float _nextAttackTime = 0f;
        private Animator _animator;
        private bool _attacking;

        private int _animatorAttackTrigger;
        [SerializeField]
        private Transform _attackArea;

        private void Start()
        {
            _animatorAttackTrigger = Animator.StringToHash("attack");
            _animator = GetComponent<Animator>();
            _attackArea = gameObject.transform.Find("AttackArea");
            layer = LayerMask.GetMask("Enemy");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && CharacterSelect.Instance.IsCharacterSelected(gameObject) && Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + 1f / _attackRate;
                Attack();
            }
        }

        private void Attack()
        {
            _animator.SetTrigger(_animatorAttackTrigger);
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackArea.position, attackRange, layer);
            SoundManager.Instance.PlaySound(hitEnemies.Length > 0 ? "Explosion" : "Punch Miss");
            
            foreach (var hitEnemy in hitEnemies)
            {
                hitEnemy.GetComponent<IDamageable>().TakeDamage(attackDamage);
            }
        }
    }
}
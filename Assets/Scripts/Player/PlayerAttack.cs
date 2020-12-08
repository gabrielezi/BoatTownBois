using Fight.Attack;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float attackRate = 1f;
        
        private float _nextAttackTime = 0f;
        private Animator _animator;
        private int _animatorAttackTrigger;
        private IAttack _attack;

        private void Start()
        {
            _animatorAttackTrigger = Animator.StringToHash("attack");
            _animator = GetComponent<Animator>();
            _attack = gameObject.GetComponent<IAttack>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && CharacterSelect.Instance.IsCharacterSelected(gameObject) && Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + 1f / attackRate;
                SoundManager.Instance.PlaySound("Punch Miss");
                Attack();
            }
        }

        private void Attack()
        {
            _animator.SetTrigger(_animatorAttackTrigger);
            _attack.Attack();
        }
    }
}

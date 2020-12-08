using Fight.Damage;
using UnityEngine;

namespace Fight.Attack
{
    public class AreaAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private int attackDamage = 20;
        [SerializeField] private LayerMask layer;
        [SerializeField] private Transform attackArea;

        public void Attack()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackArea.position, attackRange, layer);

            foreach (var hitEnemy in hits)
            {
                hitEnemy.GetComponent<IDamageable>()?.TakeDamage(attackDamage);
            }
        }
    }
}

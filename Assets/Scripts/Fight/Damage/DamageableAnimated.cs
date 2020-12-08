using Fight.Destroy;
using UnityEngine;
using UnityEngine.Events;

namespace Fight.Damage
{
    public class DamageableAnimated : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health;
        [SerializeField] private string animatorHitTriggerName = "hit";
        [SerializeField] private string animatorIsDownName = "isDown";
        [SerializeField] private UnityEvent onDown = new UnityEvent();

        private Animator _animator;
        private int _animatorHitTrigger;
        private int _animatorIsDown;
        private int _maxHealth;

        private IDestroy _destroy;
        private HealthBarManager _hpBarManager;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _animatorHitTrigger = Animator.StringToHash(animatorHitTriggerName);
            _animatorIsDown = Animator.StringToHash(animatorIsDownName);
            _destroy = gameObject.GetComponent<IDestroy>();
            _hpBarManager = gameObject.GetComponent<HealthBarManager>();
            _maxHealth = health;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            _hpBarManager.UpdateHealthBar(_maxHealth, health);

            if (health > 0)
            {
                _animator.SetTrigger(_animatorHitTrigger);
            }
            else
            {
                _animator.SetBool(_animatorIsDown, true);
                GetComponent<Collider2D>().enabled = false;
                onDown?.Invoke();
                _destroy.DestroyObject();
            }
        }
    }
}

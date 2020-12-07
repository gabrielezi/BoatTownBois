using UnityEngine;

namespace Enemy
{
    public class BasicEnemy : MonoBehaviour
    {
        public int maxHealth = 100;

        private int _currentHealth;

        private Animator _animator;
        private int _animatorHitTrigger;
        private int _animatorIsDown;

        private void Start()
        {
            _currentHealth = maxHealth;
            _animator = gameObject.GetComponent<Animator>();
            _animatorHitTrigger = Animator.StringToHash("hit");
            _animatorIsDown = Animator.StringToHash("isDown");
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth > 0)
            {
                _animator.SetTrigger(_animatorHitTrigger);
            }
            else
            {
                _animator.SetBool(_animatorIsDown, true);
                GetComponent<Collider2D>().enabled = false;
                MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
                foreach (var script in scripts)
                {
                    script.enabled = false;
                }

                Destroy(gameObject);
            }
        }
    }
}

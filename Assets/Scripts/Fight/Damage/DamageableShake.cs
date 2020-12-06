using System.Collections;
using Fight.Destroy;
using UnityEngine;

namespace Fight.Damage
{
    public class DamageableShake : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private int health;
        [SerializeField]
        private float timeToShake = 0.3f;
        [SerializeField]
        private float shakingIntensity = 0.05f;

        private IDestroy _destroy;
        private HealthBarManager _hpBarManager;
        private float _timer;
        private Vector3 _randomPos;
        private Vector3 _startPos;
        private int _maxHealth;
        
        private void Start()
        {
            _destroy = gameObject.GetComponent<IDestroy>();
            _hpBarManager = gameObject.GetComponent<HealthBarManager>();
            _maxHealth = health;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            _hpBarManager.UpdateHealthBar(_maxHealth, health);
            StartCoroutine(Shake());
            
            if (health <= 0)
            {
                GetComponent<Collider2D>().enabled = false;
                _destroy.DestroyObject();
            }
        }
        
        private IEnumerator Shake()
        {
            _timer = 0f;
            _startPos = transform.position;

            while (_timer < timeToShake)
            {
                _timer += Time.deltaTime;
 
                transform.position += (Random.insideUnitSphere * shakingIntensity);

                yield return null;
            }
            transform.position = _startPos;
        }
    }
}
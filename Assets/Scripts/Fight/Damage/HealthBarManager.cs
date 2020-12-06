using UnityEngine.UI;
using UnityEngine;

namespace Fight.Damage
{
    public class HealthBarManager : MonoBehaviour
    {
        private Slider _healthBar;
        
        private void Start()
        {
            _healthBar = gameObject.transform.Find("Hp").Find("Slider").GetComponent<Slider>();
            _healthBar.gameObject.SetActive(false);
            _healthBar.value = 0;
        }

        public void UpdateHealthBar(int maxHeath, int currentHealth)
        {
            _healthBar.gameObject.SetActive(true);
            _healthBar.value = (float) currentHealth / maxHeath;
        }
    }
}
using UnityEngine;

namespace ResourceGathering
{
    public class DropCollector : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
                ResourceManager.Instance.AddResource(ResourceEnum.Coin, 1);
                SoundManager.Instance.PlaySound("Coin");
            } else if (other.gameObject.CompareTag("Wood"))
            {
                Destroy(other.gameObject);
                ResourceManager.Instance.AddResource(ResourceEnum.Wood, 20);
            }
        }
    }
}
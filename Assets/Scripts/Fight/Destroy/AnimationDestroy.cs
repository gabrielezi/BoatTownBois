using UnityEngine;

namespace Fight.Destroy
{
    public class AnimationDestroy : MonoBehaviour, IDestroy
    {
        [SerializeField] private string triggerName;
        [SerializeField] private float delay;
        
        public void DestroyObject()
        {
            gameObject.GetComponent<Animator>().SetTrigger(triggerName);
            
            Destroy(gameObject, delay);
        }
    }
}

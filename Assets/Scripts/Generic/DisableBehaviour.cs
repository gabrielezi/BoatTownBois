using UnityEngine;

namespace Generic
{
    public class DisableBehaviour : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] behaviours;
        
        public void Disable()
        {
            foreach (var behaviour in behaviours)
            {
                behaviour.enabled = false;
            }
        }
    }
}

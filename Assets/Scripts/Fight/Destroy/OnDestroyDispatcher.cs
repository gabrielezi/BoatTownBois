using UnityEngine;

namespace Fight.Destroy
{
    public class OnDestroyDispatcher : MonoBehaviour
    {
        public event System.Action<GameObject> OnObjectDestroyed;

        private void OnDestroy()
        {
            OnObjectDestroyed?.Invoke(gameObject);
        }
    }
}

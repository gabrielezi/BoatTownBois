using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Generic
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnd = new UnityEvent();
        [SerializeField] private float duration;

        private void Start()
        {
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(duration);
            
            onEnd?.Invoke();
        }
    }
}

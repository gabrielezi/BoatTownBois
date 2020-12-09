using System.Collections;
using Generic.EventGameObject;
using UnityEngine;
using EventType = Generic.EventGameObject.EventType;

namespace Fight.Destroy
{
    public class FadeDestroy : MonoBehaviour, IDestroy
    {
        private EventDispatcher _eventDispatcher;

        private void Start()
        {
            _eventDispatcher = FindObjectOfType<EventDispatcher>();
        }

        public void DestroyObject()
        {
            StartCoroutine(Fade(gameObject.GetComponent<SpriteRenderer>()));
        }

        IEnumerator Fade(SpriteRenderer spriteRenderer)
        {
            var waitForFixedUpdate = new WaitForFixedUpdate();
            for (float ft = 1f; ft >= 0; ft -= 0.02f)
            {
                Color color = spriteRenderer.color;
                color.a = ft;
                spriteRenderer.color = color;
                yield return waitForFixedUpdate;
            }

            if (_eventDispatcher != null)
            {
                _eventDispatcher.Dispatch(new GameObjectEvent(gameObject, EventType.OnDestroy));
            }

            Destroy(gameObject);
        }
    }
}

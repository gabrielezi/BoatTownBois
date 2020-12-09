using UnityEngine;
using UnityEngine.Events;

namespace Generic
{
    public class ClickedEventTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onClick = new UnityEvent();
        
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject.name == gameObject.name)
                {
                    onClick?.Invoke();
                }
            }
        }
    }
}

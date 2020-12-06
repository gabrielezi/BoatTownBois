using UnityEngine;

namespace Player
{
    public class CharacterSelector : MonoBehaviour
    {
        private Camera _camera;
        
        private void Start()
        {
            _camera = Camera.main;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Player Character"))
                {
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        CharacterSelect.Instance.ToggleCharacterSelection(hit.collider.gameObject);
                    }
                    else
                    {
                        CharacterSelect.Instance.SetSelectedCharacter(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private void OnDestroy()
        {
            CharacterSelect.Instance.RemoveCharacter(gameObject);
        }
    }
}

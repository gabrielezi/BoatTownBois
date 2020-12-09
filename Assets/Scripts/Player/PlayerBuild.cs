using Assets.Scripts;
using UnityEngine;

namespace Player
{
    public class PlayerBuild : MonoBehaviour
    {
        [SerializeField] private GameObject building;
        private bool _buildMenuActivated = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) && CharacterSelect.Instance.IsCharacterSelected(gameObject) && CharacterSelect.Instance.GetFirstCharacter() == gameObject)
            {
                if (!_buildMenuActivated)
                {
                    BuildManager.Instance.ActivateBuildUI(() => { return gameObject.transform.position; });
                    _buildMenuActivated = true;
                } 
                else
                {
                    BuildManager.Instance.DisableBuildUI();
                    _buildMenuActivated = false;
                }
            }
        }

        private void OnDestroy()
        {
            BuildManager.Instance.DisableBuildUI();

        }

        public float GetBuildTime()
        {
            return BuildManager.DefaultBuildTime;
        }
    }
}

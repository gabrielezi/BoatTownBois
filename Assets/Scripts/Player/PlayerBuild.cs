using UnityEngine;

namespace Player
{
    public class PlayerBuild : MonoBehaviour
    {
        [SerializeField]
        private GameObject building;

        private bool _isBuilding;
        private const float DefaultBuildTime = 3; 
        private float _buildTimeRemaining = DefaultBuildTime;
        private Vector3 _buildingPosition;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B) && CharacterSelect.Instance.IsCharacterSelected(gameObject) && !_isBuilding)
            {
                var wood = ResourceManager.Instance.GetResource(ResourceEnum.Wood);
                var stone = ResourceManager.Instance.GetResource(ResourceEnum.Stone);
                if (wood < 200 || stone < 25)
                {
                    //TODO: print message to player;
                    print("Not enough resources!");
                } 
                else
                {
                    _buildingPosition = transform.position;
                    _buildingPosition.y -= 0.01f;
                    SoundManager.Instance.PlaySound("Build");
                    ResourceManager.Instance.AddResource(ResourceEnum.Wood, -200);
                    ResourceManager.Instance.AddResource(ResourceEnum.Stone, -25);
                    _isBuilding = true;
                }
            }
            if (_isBuilding)
            {
                if(_buildTimeRemaining > 0)
                {
                    _buildTimeRemaining -= Time.deltaTime;
                } 
                else
                {
                    Instantiate(building, _buildingPosition, Quaternion.identity);
                    SoundManager.Instance.StopSound("Build");
                    _isBuilding = false;
                    _buildTimeRemaining = DefaultBuildTime;
                }
            }
        }

        public float GetBuildTime()
        {
            return DefaultBuildTime;
        }
    }
}

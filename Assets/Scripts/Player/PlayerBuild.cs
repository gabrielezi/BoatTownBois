using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private GameObject _building;

    private bool _isBuilding = false;
    private const float defaultBuildTime = 3; 
    private float _buildTimeRemaining = defaultBuildTime;
    private Vector3 _nextBuildPosition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b") && !_isBuilding)
        {
            var wood = ResourceManager.Instance.GetResource(ResourceEnum.Wood);
            var stone = ResourceManager.Instance.GetResource(ResourceEnum.Stone);
            if (wood < 100 || stone < 50)
            {
                //TODO: print message to player;
                print("Not enough resources!");
            } 
            else
            {
                _nextBuildPosition = transform.position;
                SoundManager.Instance.PlaySound("Build");
                ResourceManager.Instance.AddResource(ResourceEnum.Wood, -100);
                ResourceManager.Instance.AddResource(ResourceEnum.Stone, -50);
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
                Instantiate(_building, _nextBuildPosition, Quaternion.identity);
                SoundManager.Instance.StopSound("Build");
                _isBuilding = false;
                _buildTimeRemaining = defaultBuildTime;
            }
        }
    }
}

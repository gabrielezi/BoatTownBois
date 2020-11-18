using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private GameObject _building;
    [SerializeField]
    private GameObject _slider;
    // Start is called before the first frame update

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
            SoundManager.Instance.PlaySound("Build");
            //Instantiate(_slider, _nextBuildPosition, Quaternion.identity);
            //todo: use resources
            _isBuilding = true;
            _nextBuildPosition = transform.position;
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

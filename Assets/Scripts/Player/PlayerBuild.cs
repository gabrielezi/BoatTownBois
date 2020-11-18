using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField]
    private GameObject _building;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            //todo: use resources
            Instantiate(_building, transform.position, Quaternion.identity);
        }
    }
}

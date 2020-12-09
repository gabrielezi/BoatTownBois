using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _coin;
    private int _dropAmount = 1;

    void Start()
    {
        InvokeRepeating("GenerateCoin", 1.0f, 7.0f);
        switch (gameObject.name)
        {
            case "SmallHouse(Clone)":
                _dropAmount = 1;
                break;
            case "MediumHouse(Clone)":
                _dropAmount = 2;
                break;
            case "BigHouse(Clone)":
                _dropAmount = 4;
                break;
            case "BiggestHouse(Clone)":
                _dropAmount = 6;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateCoin()
    {
        for (int i = 0; i < _dropAmount; i++)
        {
            Instantiate(_coin,
                new Vector3(Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f),
                            Random.Range(transform.position.y - 1f, transform.position.y - 0.5f),
                            Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f)),
                Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject Coin;

    void Start()
    {
        print("I am a building");
        InvokeRepeating("GenerateCoin", 1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateCoin()
    {
        print("Building has generated a coin!");
        //ResourceManager.Instance.AddResource(ResourceEnum.Coin, 1);

        Instantiate(Coin,
            //transform.position, 
            new Vector3(Random.Range(transform.position.x - 0.5f, transform.position.x + 0.5f), 
                        Random.Range(transform.position.y - 1f, transform.position.y - 0.5f), 
                        Random.Range(transform.position.z - 0.5f, transform.position.z + 0.5f)),
            Quaternion.identity);
    }
}

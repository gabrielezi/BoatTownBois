using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    private Dictionary<ResourceEnum, int> _resources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _resources = new Dictionary<ResourceEnum, int>();
        _resources.Add(ResourceEnum.Wood, 0);
        _resources.Add(ResourceEnum.Stone, 0);
    }

    public void AddResource(ResourceEnum resourceType, int amount)
    {
        _resources[resourceType] += amount;
        UpdateResourceDisplay();
    }
    public int GetResource(ResourceEnum resourceType)
    {
        return _resources[resourceType];
    }

    public void UpdateResourceDisplay()
    {
        Text textWood = GameObject.Find("Wood_Count_Text").GetComponent<Text>();
        textWood.text = (_resources[ResourceEnum.Wood]).ToString();

        Text textStone = GameObject.Find("Stone_Count_Text").GetComponent<Text>();
        textStone.text = (_resources[ResourceEnum.Stone]).ToString();
    }
}


public enum ResourceEnum
{
    Wood,
    Stone
}

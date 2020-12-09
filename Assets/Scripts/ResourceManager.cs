using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;
    private Dictionary<ResourceEnum, int> _resources;
    private Text _woodCountText;
    private Text _stoneCountText;
    private Text _coinCountText;

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
        _resources.Add(ResourceEnum.Wood, 1000);
        _resources.Add(ResourceEnum.Stone, 1000);
        _resources.Add(ResourceEnum.Coin, 0);
    }
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _woodCountText = GameObject.Find("Wood_Count_Text").GetComponent<Text>();
        _stoneCountText = GameObject.Find("Stone_Count_Text").GetComponent<Text>();
        _coinCountText = GameObject.Find("Coin_Count_Text").GetComponent<Text>();
        UpdateResourceDisplay();
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
        _woodCountText.text = _resources[ResourceEnum.Wood].ToString();
        _stoneCountText.text = _resources[ResourceEnum.Stone].ToString();
        _coinCountText.text = _resources[ResourceEnum.Coin].ToString();
    }
}

public enum ResourceEnum
{
    Wood,
    Stone,
    Coin
}

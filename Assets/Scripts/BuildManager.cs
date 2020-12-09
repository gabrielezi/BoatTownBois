using Assets.Scripts.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Building;

namespace Assets.Scripts
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager Instance;
        private static GameObject BuildUI;
        private static Func<Vector3> _getPlayerPosition;
        private static bool _isBuilding;
        public const float DefaultBuildTime = 3;
        private static float _buildTimeRemaining = DefaultBuildTime;
        private static Vector3 _buildingPosition;
        private static GameObject _buildingToBeBuilt;

        private static Dictionary<BuildingEnum, Dictionary<ResourceEnum, int>> _resourcesNeeded;

        private void Start()
        {
            InitNeededResources();
        }

        private void InitNeededResources()
        {
            _resourcesNeeded = new Dictionary<BuildingEnum, Dictionary<ResourceEnum, int>>()
            {
                {
                    BuildingEnum.SmallHouse, new Dictionary<ResourceEnum, int>
                    {
                        {ResourceEnum.Wood, 50},
                        {ResourceEnum.Stone, 50}
                    }
                    },
                {
                    BuildingEnum.MediumHouse, new Dictionary<ResourceEnum, int>
                    {
                        {ResourceEnum.Wood, 150},
                        {ResourceEnum.Stone, 100}
                    }
            },
            {
                    BuildingEnum.BigHouse, new Dictionary<ResourceEnum, int>
                    {
                        {ResourceEnum.Wood, 200},
                        {ResourceEnum.Stone, 150}
                    }
                    },
                {
                    BuildingEnum.BiggestHouse, new Dictionary<ResourceEnum, int>
                    {
                        {ResourceEnum.Wood, 300},
                        {ResourceEnum.Stone, 250}
                    }
                }
            };
        }

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

            BuildUI = GameObject.Find("BuildPickUI");
            DontDestroyOnLoad(gameObject);
        }

        public void ActivateBuildUI(Func<Vector3> getPlayerPosition)
        {
            //print("Activate build ui!");
            //_getPlayerPosition = getPlayerPosition;
            //var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            //var buildUI = objects.Where(o => o.name == "BuildPickUI").ToList();
            //buildUI.ForEach(b => b.SetActive(true));

            _getPlayerPosition = getPlayerPosition;
            if(BuildUI == null)
            {
                BuildUI = GameObject.Find("BuildPickUI");
            }
            BuildUI?.SetActive(true);
        }

        public void DisableBuildUI()
        {
            //print("Disable build ui!");
            //var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            //var buildUI = objects.FirstOrDefault(o => o.name == "BuildPickUI");
            //buildUI.SetActive(false);
            if (BuildUI == null)
            {
                BuildUI = GameObject.Find("BuildPickUI");
            }
            BuildUI?.SetActive(false);
        }

        public void AttemptBuild(BuildingEnum building)
        {
            if (!_isBuilding)
            {
                var currentWood = ResourceManager.Instance.GetResource(ResourceEnum.Wood);
                var currentStone = ResourceManager.Instance.GetResource(ResourceEnum.Stone);
                var currentCoin = ResourceManager.Instance.GetResource(ResourceEnum.Coin);
                if (_resourcesNeeded[building][ResourceEnum.Wood] <= currentWood &&
                    _resourcesNeeded[building][ResourceEnum.Stone] <= currentStone)
                {
                    _buildingPosition = _getPlayerPosition();
                    _buildingPosition.y -= 0.01f;
                    SoundManager.Instance.PlaySound("Build");
                    ResourceManager.Instance.AddResource(ResourceEnum.Wood, -_resourcesNeeded[building][ResourceEnum.Wood]);
                    ResourceManager.Instance.AddResource(ResourceEnum.Stone, -_resourcesNeeded[building][ResourceEnum.Stone]);
                    _buildingToBeBuilt = (GameObject)Resources.Load("Prefabs/" + building.ToString(), typeof(GameObject));
                    _isBuilding = true;
                }
            }
        }

        private void Update()
        {
            if (_isBuilding)
            {
                if (_buildTimeRemaining > 0)
                {
                    _buildTimeRemaining -= Time.deltaTime;
                }
                else
                {
                    Instantiate(_buildingToBeBuilt, _buildingPosition, Quaternion.identity);
                    SoundManager.Instance.StopSound("Build");
                    _isBuilding = false;
                    _buildTimeRemaining = DefaultBuildTime;
                }
            }
        }
    }
}

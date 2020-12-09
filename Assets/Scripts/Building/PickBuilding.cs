using Assets.Scripts;
using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickBuilding : MonoBehaviour
{

    void Start()
    {
        var buildButtons = new Dictionary<BuildingEnum, Button>()
        {
            {  BuildingEnum.SmallHouse, GameObject.Find("smallHouseButton").GetComponent<Button>()  },
            {  BuildingEnum.MediumHouse, GameObject.Find("mediumHouseButton").GetComponent<Button>()  },
            {  BuildingEnum.BigHouse, GameObject.Find("bigHouseButton").GetComponent<Button>()  },
            {  BuildingEnum.BiggestHouse, GameObject.Find("biggestHouseButton").GetComponent<Button>()  },

        };
        foreach(var b in buildButtons)
        {
            b.Value.onClick.AddListener(() => TaskOnClick(b.Key));
        }
        gameObject.SetActive(false);
    }

    void TaskOnClick(BuildingEnum building)
    {
        print("Clicked on" + building.ToString());
        BuildManager.Instance.AttemptBuild(building);
    }
}

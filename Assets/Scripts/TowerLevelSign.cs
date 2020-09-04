using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerLevelSign : MonoBehaviour
{
    public GameObject tower;

    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(tower.transform.position);
        GetComponent<Text>().text = "lvl: " + tower.GetComponent<TowerScript>().towerLevel.ToString() + "\nnext lvl cost: " + tower.GetComponent<TowerScript>().modifyPrice;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypeControllerScript : MonoBehaviour
{
    public int currentTowerType;

    public void TowerTypeChange(int type){
    		Debug.Log("ТЫК ПО КНОПКЕ");
    		currentTowerType = type;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreateScript : MonoBehaviour
{
    public GameObject tower;
    public GameObject towerRed;
    public GameObject towerBlue;
    public GameObject towerTypeController;
    public GameObject currentTower;
    public GameObject gold;
    public GameObject levelSign;
    public GameObject canvas;
    public Vector3 offset;
    public bool empty;
    
    void OnMouseDown(){
    	if (towerTypeController.GetComponent<TowerTypeControllerScript>().currentTowerType == 0){
    		tower = towerRed;
    	} else {
    		tower = towerBlue;
    	}

    	if(empty){

    		if (gold.GetComponent<MoneyScript>().currentMoney >= tower.GetComponent<TowerScript>().towerPrice){
    			gold.GetComponent<MoneyScript>().currentMoney -= tower.GetComponent<TowerScript>().towerPrice;
				currentTower = GameObject.Instantiate(tower, transform.position + offset, Quaternion.identity) as GameObject;
				GameObject lvlSign = GameObject.Instantiate(levelSign, Vector3.zero, Quaternion.identity) as GameObject;
        		lvlSign.transform.SetParent(canvas.transform);
        		lvlSign.GetComponent<TowerLevelSign>().tower = currentTower;
				currentTower.GetComponent<TowerScript>().gold = gold;
				Debug.Log("Create tower!");
                empty = false;
    		}
    	}
    	
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    public TowerScript tower;
    public Transform enemy;
    public bool lockTargetEnemy; 
    public GameObject currentTarget;

    void OnMouseDown(){
    	if(tower.GetComponent<TowerScript>().towerLevel <= tower.GetComponent<TowerScript>().maxLevel){
    		if (tower.GetComponent<TowerScript>().gold.GetComponent<MoneyScript>().currentMoney >= tower.GetComponent<TowerScript>().modifyPrice){
    			tower.GetComponent<TowerScript>().gold.GetComponent<MoneyScript>().currentMoney -= tower.GetComponent<TowerScript>().modifyPrice;
				tower.GetComponent<TowerScript>().towerLevel += 1;
				tower.GetComponent<TowerScript>().modifyPrice *= 2;
    		}
    	}
    }

    void OnTriggerEnter(Collider other){
    	if(other.CompareTag("enemy") && !lockTargetEnemy){
    		tower.target = other.gameObject.transform;
    		lockTargetEnemy = true;
    	}
    }

    void OnTriggerExit(Collider other){
    	if (other.CompareTag("enemy") && other.gameObject == currentTarget){
    		lockTargetEnemy = false;
    	}
    }

    void Update(){
    	if (!currentTarget){
    		lockTargetEnemy = false;
    	}
    }
}

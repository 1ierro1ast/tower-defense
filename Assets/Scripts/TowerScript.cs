using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
	public Transform shootElement;
	public Transform lookAtObject;
	public int damage;
	public int maxDamage;
	public GameObject bullet;
	public Transform target;
	public int towerPrice;
    public int modifyPrice;
	public float shootDelay;
	public int towerLevel;
	public int maxLevel;
	public GameObject gold;
	bool isShoot;
    
    void Update()
    {
        if(target){
        	lookAtObject.transform.LookAt(target);
        }

        if (!isShoot){
        	StartCoroutine(shoot());
        }

        switch (towerLevel){
        	case 2:
        		shootDelay = 0.5f;
        		break;
        	case 3:
        		damage = maxDamage;
        		break;
        	default:
        		break;
        }
    }

    IEnumerator shoot(){
    	isShoot = true;
    	yield return new WaitForSeconds(shootDelay);
    	GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
    	b.GetComponent<BulletScript>().target = target;
    	b.GetComponent<BulletScript>().tower = this;
    	isShoot = false;
    }
}

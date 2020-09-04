using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	public float bulletSpeed;
	public Transform target;
	public TowerScript tower;
    
    void Update()
    {
        if (!target){
        	Destroy(gameObject);
        } else {
        	transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * bulletSpeed);
        	transform.LookAt(target);
        }
    }

    void OnTriggerEnter(Collider other){
    	if (other.gameObject.transform == target){
    		target.GetComponent<MobScript>().hp.GetComponent<Hp>().Damage(tower.damage);
    		Destroy(gameObject);
    	}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobScript : MonoBehaviour
{
    
    public float speed;
    public Transform[] targets;
    public GameObject hp;
    public GameObject gold;
    int currentTarget = 0;

    void Update()
    {
    	if (currentTarget <= targets.Length ){
	        transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget].position, Time.deltaTime * speed);
	        transform.LookAt(targets[currentTarget]);
	        if (Vector3.Distance(transform.position, targets[currentTarget].position) < 0.5f){
	        	currentTarget++;
	        }

            if(hp.GetComponent<Hp>().EnemyHp <= 0){
                gold.GetComponent<MoneyScript>().currentMoney += 10;
                Destroy(gameObject);
                Destroy(hp);
            }
    	}
    }
}

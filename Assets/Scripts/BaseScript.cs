using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    public int hp = 100;
    public Text hpText;
    public GameObject LoseSign;
    public GameObject canvas;

    void Update()
    {
        hpText.text = "HP: " + hp.ToString();
        if (hp <= 0){
        	hp = 0;
        	Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
    	if (other.CompareTag("enemy")){
    		hp -= 10;
    		Destroy(other.gameObject);
    		Destroy(other.GetComponent<MobScript>().hp);
    	}
    }
}

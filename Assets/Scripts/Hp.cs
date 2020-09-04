using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public GameObject enemy;
    public int EnemyHp = 30;

    public void Damage(int damageValue){
        EnemyHp -= damageValue;
    }

    void Update(){
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        GetComponent<Text>().text = EnemyHp.ToString();
    }
}

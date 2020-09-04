using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public int currentMoney;

    void Update()
    {
        GetComponent<Text>().text = "Gold: " + currentMoney.ToString();
    }
}

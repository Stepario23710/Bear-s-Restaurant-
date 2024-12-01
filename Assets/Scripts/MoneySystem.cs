using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] private Text moneyCounter;
    private int playerMoney = 0;
    void Start()
    {
        MoneyInc(300);
    }
    public void MoneyInc(int inc){
        if (inc < 0){
            inc = 0;
        }
        playerMoney += inc;
        moneyCounter.text = (Convert.ToInt32(moneyCounter.text) + inc).ToString();
    }
}
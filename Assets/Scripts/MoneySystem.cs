using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] private Text moneyCounter;
    [SerializeField] private int firstMoney;
    private int playerMoney = 0;
    void Start()
    {
        MoneyInc(firstMoney);
        gameObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    }
    public void MoneyInc(int inc){
        playerMoney += inc;
        moneyCounter.text = (Convert.ToInt32(moneyCounter.text) + inc).ToString();
    }
    public int CheckMoney(){
        return playerMoney;
    }
}

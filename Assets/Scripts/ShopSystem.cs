using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuOfShop;
    [SerializeField] private GameObject[] subMenuesOfShop = new GameObject[3];
    [SerializeField] private Sprite[] fruitsSpr = new Sprite[2];
    [SerializeField] private Sprite[] berriesSpr = new Sprite[3];
    [SerializeField] private int[] prices = new int[16];
    private int nowFruit = 0;
    private int nowBerry = 0;
    private bool isActivate;
    private Dictionary<int, int> priceAndThing;
    void Start(){
        int c = 0;
        CheckWhatCanYouBuy();
        for (int i = 0; i < subMenuesOfShop.Length; i++){
            subMenuesOfShop[i].SetActive(false);
            for (int j = 0; j < (subMenuesOfShop[i].transform.childCount - 1); j++){
                subMenuesOfShop[i].transform.GetChild(j).GetChild(0).GetChild(0).GetComponent<Text>().text += prices[c].ToString();
                c += 1;
                if (c == 4){
                    c = 10;
                } else if (c == 11){
                    c = 13;
                } else if (c == 14){
                    c = 15;
                }
            }
        }
        menuOfShop.SetActive(false);
    }
    public void ActivateMenu(int num){
        if (num == 0){
            menuOfShop.SetActive(isActivate);
            gameObject.GetComponent<Button>().interactable = !isActivate;
            transform.parent.GetChild(0).GetComponent<Button>().interactable = !isActivate;
        } else {
            subMenuesOfShop[num - 1].SetActive(isActivate);
            for (int i = 0; i < menuOfShop.transform.childCount; i++){
                menuOfShop.transform.GetChild(i).GetComponent<Button>().interactable = !isActivate;
            }
        }
    }
    public void SetIsActivate(bool isActivate){
        this.isActivate = isActivate;
    }
    public void ChangeFruit(bool isFruit){
        if (isFruit){
            nowFruit += 1;
            if (nowFruit > fruitsSpr.Length - 1){
                nowFruit = 0;
            }
            subMenuesOfShop[1].transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = fruitsSpr[nowFruit];
        } else {
            nowBerry += 1;
            if (nowBerry > berriesSpr.Length - 1){
                nowBerry = 0;
            }
            subMenuesOfShop[1].transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = berriesSpr[nowBerry];
        }
    }
    public void BuySomething(int num){
        int inc = 2;
        if (num == 10){
            num += nowBerry;
            inc--;
        } else if (num == 13){
            num += nowFruit;
            inc--;
        } else if (num == 15){
            inc--;
        }
        transform.parent.GetComponent<MoneySystem>().MoneyInc(-prices[num]);
        transform.parent.GetChild(0).GetComponent<InventSystem>().UpdateInc(inc);
        transform.parent.GetChild(0).GetComponent<InventSystem>().UpdateInvent(new int[]{num});
        CheckWhatCanYouBuy();
    }
    private void CheckWhatCanYouBuy(){
        int money = transform.parent.GetComponent<MoneySystem>().CheckMoney();
        int c = 0;
        for (int i = 0; i < subMenuesOfShop.Length; i++){
            for (int j = 0; j < (subMenuesOfShop[i].transform.childCount - 1); j++){
                if (prices[c] > money){
                    subMenuesOfShop[i].transform.GetChild(j).GetChild(subMenuesOfShop[i].transform.GetChild(j).childCount - 1).
                     GetComponent<Button>().interactable = false;
                }
                c += 1;
                if (c == 4){
                    c = 10;
                } else if (c == 11){
                    c = 13;
                } else if (c == 14){
                    c = 15;
                }
            }
        }
    }
}

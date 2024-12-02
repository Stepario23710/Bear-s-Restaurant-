using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private GameObject menuOfShop;
    [SerializeField] private GameObject[] subMenuesOfShop = new GameObject[3];
    private bool isActivate;
    void Start(){
        menuOfShop.SetActive(false);
        for (int i = 0; i < subMenuesOfShop.Length; i++){
            subMenuesOfShop[i].SetActive(false);
        }
    }
    public void ActivateMenu(int num){
        if (num == 0){
            menuOfShop.SetActive(isActivate);
            gameObject.GetComponent<Button>().interactable = !isActivate;
        } else {
            subMenuesOfShop[num - 1].SetActive(isActivate);
            for (int i = 0; i < menuOfShop.transform.childCount; i++){
                menuOfShop.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = !isActivate;
            }
        }
    }
    public void SetIsActivate(bool isActivate){
        this.isActivate = isActivate;
    }
}

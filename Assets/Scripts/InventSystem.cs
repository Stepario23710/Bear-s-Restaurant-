using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventSystem : MonoBehaviour
{
    [SerializeField] private GameObject invent;
    private int[] inventList;
    private int inc;
    void Start()
    {
        inventList = new int[invent.transform.childCount - 1];
        UpdateInvent(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15});
        invent.SetActive(false);
    }
    public void ActivateMenu(bool isActivate){
        invent.SetActive(isActivate);
        gameObject.GetComponent<Button>().interactable = !isActivate;
        transform.parent.GetChild(1).GetComponent<Button>().interactable = !isActivate;
    }
    public void UpdateInvent(int[] things){
        for (int i = 0; i < things.Length; i++){
            inventList[things[i]] += inc; 
            invent.transform.GetChild(things[i]).GetChild(0).GetComponent<Text>().text = "x" + inventList[things[i]].ToString();
        }
    }
    public void UpdateInc(int inc){
        this.inc = inc;
    }
}

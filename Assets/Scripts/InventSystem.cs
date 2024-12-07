using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventSystem : MonoBehaviour
{
    [SerializeField] private GameObject invent;
    private int[] inventList;
    void Start()
    {
        inventList = new int[invent.transform.childCount - 1];
        UpdateInvent(new (int, int)[]{(0, 0),(1, 0),(2, 0),(3, 0),(4, 5),(5, 15),(6, 15),(7, 15),(8, 5),(9, 5),
         (10, 0),(11, 0),(12, 0),(13, 0),(14, 0),(15, 0)});
        invent.SetActive(false);
    }
    public void ActivateMenu(bool isActivate){
        invent.SetActive(isActivate);
        gameObject.GetComponent<Button>().interactable = !isActivate;
        transform.parent.GetChild(1).GetComponent<Button>().interactable = !isActivate;
    }
    public void UpdateInvent((int, int)[] things){
        for (int i = 0; i < things.Length; i++){
            inventList[things[i].Item1] += things[i].Item2; 
            invent.transform.GetChild(things[i].Item1).GetChild(0).GetComponent<Text>().text = "x" + inventList[things[i].Item1].ToString();
        }
    }
}

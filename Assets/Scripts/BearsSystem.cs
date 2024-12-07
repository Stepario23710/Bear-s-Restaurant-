using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Linq;

public class BearsSystem : MonoBehaviour
{
    [SerializeField] private GameObject bearOrig;
    [SerializeField] private float timeBeforeNewBear;
    [SerializeField] private string[] menuOfRest;
    [SerializeField] private string[] menuOfJuiceAndPie;
    [SerializeField] private string[] menuOfSalatAndShake;
    [SerializeField] private string[] menuOfCoffee;
    private GameObject[] bears = new GameObject[3];
    private (int, int)[][][] orders = new (int, int)[3][][];
    private int nowBear;
    void Start()
    {
        NewBear();
    }
    private void NewBear(){
        int c = 0;
        for (int i = 0; i < bears.Length; i++){
            c += 1;
            if (bears[i] == null){
                bears[i] = Instantiate(bearOrig);
                bears[i].GetComponent<Animator>().SetInteger("TableNum", i + 1);
                nowBear = i;
                Invoke(nameof(OrdersOfBear), 7 + i);
                break;
            }
        }
        if (c < bears.Length){
            Invoke(nameof(NewBear), timeBeforeNewBear);
        }
    }
    private void OrdersOfBear(){
        int i = nowBear;
        var ord1 = DoOrder();
        System.Random rnd = new System.Random();
        int secOrder = rnd.Next(0, 2);
        if (secOrder == 1){
            var ord2 = DoOrder();
            int thirOrder = rnd.Next(0, 4);
            if (thirOrder == 1){
                var ord3 = DoOrder();
                orders[i] = new (int, int)[][]{ord1, ord2, ord3};
            } else{
                orders[i] = new (int, int)[][]{ord1, ord2};
            }
        } else{
            orders[i] = new (int, int)[][]{ord1};
        }
    }
    private (int, int)[] DoOrder(){
        System.Random rnd = new System.Random();
        string dish = menuOfRest[rnd.Next(0, menuOfRest.Length)];
        (int, int)[] order = new (int, int)[0];
        string ext;
        var things = new List<int>();
        switch (dish){
            case "Salat":
                ext = menuOfSalatAndShake[rnd.Next(0, menuOfSalatAndShake.Length)];
                things = ext.Split(" ").Select(int.Parse).ToList();
                order = new (int, int)[3];
                order[0] = (things[0], 5);
                order[1] = (things[1], 1);
                order[2] = (2, 1);
                break;
            case "Juice":
                ext = menuOfJuiceAndPie[rnd.Next(0, menuOfJuiceAndPie.Length)];
                things = ext.Split(" ").Select(int.Parse).ToList();
                order = new (int, int)[1];
                if (things[0] == 8 || things[0] == 9){
                    order[0] = (things[0], 1);
                } else {
                    order[0] = (things[0], 10);
                }
                break;
            case "Pie":
                ext = menuOfJuiceAndPie[rnd.Next(0, menuOfJuiceAndPie.Length)];
                things = ext.Split(" ").Select(int.Parse).ToList();
                order = new (int, int)[2];
                if (things[0] == 8 || things[0] == 9){
                    order[0] = (things[0], 1);
                } else {
                    order[0] = (things[0], 10);
                }
                order[1] = (3, 1);
                break;
            case "Shake":
                ext = menuOfSalatAndShake[rnd.Next(0, menuOfSalatAndShake.Length)];
                things = ext.Split(" ").Select(int.Parse).ToList();
                order = new (int, int)[3];
                order[0] = (things[0], 5);
                order[1] = (things[1], 1);
                order[2] = (1, 1);
                break;
            case "Coffee":
                ext = menuOfCoffee[rnd.Next(0, menuOfCoffee.Length)];
                if (ext != ""){
                    things = ext.Split(" ").Select(int.Parse).ToList();
                }
                order = new (int, int)[things.Count + 1];
                order[0] = (0, 1);
                for (int i = 1; i < (things.Count + 1); i++){
                    order[i] = (things[i - 1], 1);
                }
                break;
            case "Fish":
                order = new (int, int)[1]{(4, 1)};
                break;
        }
        return order;
    }
}

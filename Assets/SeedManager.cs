using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedManager : MonoBehaviour
{
    public static float money = 0.0f;

    public GameObject seedShop;
    static Dictionary<string, int> seed_quantity = new Dictionary<string, int>();
    public static Dictionary<string, int> seedMoney = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        seed_quantity["acorn"] = 5;
        seed_quantity["maple"] = 0;
        seed_quantity["pine"] = 2;
        seed_quantity["oak"] = 0;
        seed_quantity["walnut"] = 0;
        seed_quantity["chestnut"] = 0;
        seed_quantity["coconut"] = 0;

        seedMoney.Add("acorn", 100);
        seedMoney.Add("pine", 450);
        seedMoney.Add("maple", 150);
        seedMoney.Add("chestnut", 250);
        seedMoney.Add("walnut", 900);
        seedMoney.Add("coconut", 2500);
        seedMoney.Add("oak", 300);



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int GetQuantity(string seed_name){
        return seed_quantity[seed_name];
    }

    public static void AddQuantity(string seed_name, int value){
        seed_quantity[seed_name] += value;
    }

    public void ToggleShop(){
        seedShop.SetActive(!seedShop.activeSelf);
    }

    public void buySeed(string seed_type){
        if(money >= seedMoney[seed_type]){
            seed_quantity[seed_type] += 1;
            money -= seedMoney[seed_type];
        }
    }
}

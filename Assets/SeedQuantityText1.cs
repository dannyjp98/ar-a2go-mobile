using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedQuantityText1 : MonoBehaviour
{
    public string seed_type_name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = SeedManager.GetQuantity(seed_type_name).ToString();
    }
}

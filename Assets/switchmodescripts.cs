using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class switchmodescripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "exploration_scene"){
            GetComponent<Text>().text = "Interact";
        } else {
            GetComponent<Text>().text = "Explore";
        }

    }
}

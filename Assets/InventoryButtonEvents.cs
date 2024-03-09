using Mapbox.Unity.Location;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InventoryButtonEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick(string name){
        if (SeedManager.GetQuantity(name) == 0) return;
        if (SceneManager.GetActiveScene().name == "exploration_scene") return;

        ARObjectSpawner obj = FindObjectOfType<ARObjectSpawner>();
        if(obj == null) return;

        obj.SpawnAtCursor(TreeManager.treeDictionary[name]);
        SeedManager.AddQuantity(name, -1);
        TreeManager.createTree(name, EditorLocationProviderLocationLog.current_player_position);
       
    }

    public void shootAcorn(GameObject acorn_game_obj)
    {
        if (SceneManager.GetActiveScene().name == "exploration_scene") return;
        if (SeedManager.GetQuantity("acorn") == 0) return;
        Debug.Log("here");

        ARObjectSpawner obj = FindObjectOfType<ARObjectSpawner>();
        obj.ShootObject(acorn_game_obj);
        SeedManager.AddQuantity("acorn", -1);
    }

}

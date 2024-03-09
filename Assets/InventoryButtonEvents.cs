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
        ARObjectSpawner obj = FindObjectOfType<ARObjectSpawner>();
        if(obj == null) return;
        obj.SpawnAtCursor(TreeManager.treeDictionary[name]);

        if(SceneManager.GetActiveScene().name == "exploration_scene") return;

        if(SeedManager.GetQuantity(name) > 0){
            SeedManager.AddQuantity(name, -1);
            TreeManager.createTree(name, EditorLocationProviderLocationLog.current_player_position);
        }
    }
}

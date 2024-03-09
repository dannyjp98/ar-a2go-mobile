using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SpawnTrees : MonoBehaviour
{
    public AbstractMap am;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Example());
        // List<TreeInfo> trees = TreeManager.GetTrees();

        // foreach(TreeInfo tree in trees){
        //     Vector3 scene_position = am.GeoToWorldPosition(tree.lat_long_coordinate);
        //     GameObject obj_to_spawn = TreeManager.treeDictionary[tree.tree_type];

        //     float offsetX = Random.Range(-10, 10); // Example range for x-axis offset
        //     float offsetY = Random.Range(-1, 1); // Example range for y-axis offset
        //     float offsetZ = Random.Range(-10, 10); // Example range for z-axis offset

        //     // Create a random offset
        //     Vector3 randomOffset = new Vector3(offsetX, offsetY, offsetZ);

        //     // Add the random offset to the scene position
        //     //scene_position += randomOffset;

        //     GameObject new_object = Instantiate(obj_to_spawn);
        //     Debug.Log(scene_position);
        //     new_object.transform.position = scene_position;
        //     //tree.tree_obj = new_object;



        //     // float scaleFactor = tree.growth_percentage; // Or any other scale factor you prefer
        //     // Debug.Log("GROWTH PERCENTAGE: " + tree.growth_percentage);
        //     // Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        //     // new_object.transform.localScale = newScale;

        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Example()
    {

        Debug.Log(Time.time);
        yield return new WaitForSeconds(3f);

        List<TreeInfo> trees = TreeManager.GetTrees();

        foreach(TreeInfo tree in trees){
            GameObject map_gameobject = GameObject.Find("LocationBasedGame/Map");
            AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();
            if(amap == null) Debug.Log("NO AMAP FOUND");
        Vector3 scene_position = amap.GeoToWorldPosition(tree.lat_long_coordinate);
        Debug.Log(tree.lat_long_coordinate);
        Debug.Log(scene_position);
        GameObject obj_to_spawn = TreeManager.treeDictionary[tree.tree_type];

        float offsetX = Random.Range(-10, 10); // Example range for x-axis offset
        float offsetY = Random.Range(-1, 1); // Example range for y-axis offset
        float offsetZ = Random.Range(-10, 10); // Example range for z-axis offset

        // Create a random offset
        Vector3 randomOffset = new Vector3(offsetX, offsetY, offsetZ);

        // Add the random offset to the scene position
        //scene_position += randomOffset;

        GameObject new_object = Instantiate(obj_to_spawn);
        new_object.transform.position = scene_position;
        //tree.tree_obj = new_object;



        // float scaleFactor = tree.growth_percentage; // Or any other scale factor you prefer
        // Debug.Log("GROWTH PERCENTAGE: " + tree.growth_percentage);
        // Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        // new_object.transform.localScale = newScale;

        }
    }
}
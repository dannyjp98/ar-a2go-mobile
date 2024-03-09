using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mapbox.Utils;
using Mapbox.Unity.Map;



public class SwitchModes : MonoBehaviour
{
    public GameObject pine;
    public GameObject maple;
    GameObject map_gameobject;

    static TreeInfo nearest_tree;


    public void SwitchScene(){
        if(SceneManager.GetActiveScene().name == "exploration_scene"){
            Debug.Log("Switched TO INTERACTION");

            GameObject player_obj = GameObject.Find("LocationBasedGame/PlayerTarget");
            AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();

            List<TreeInfo> trees = TreeManager.GetTrees();
            float min_dist = 9999.9f;
            foreach(TreeInfo tree in trees){
                Vector3 scene_position = amap.GeoToWorldPosition(tree.lat_long_coordinate);
                float dist = Vector3.Distance(player_obj.transform.position,scene_position);
                if(dist < min_dist){
                    min_dist = dist;
                    nearest_tree = tree;
                }
            }

            TreeManager.nearestTree = nearest_tree;

            SceneManager.LoadScene("interaction_scene");


        }else{
            SceneManager.LoadScene("exploration_scene");
        }
    }

    IEnumerator Example()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(2);
        Debug.Log(Time.time);


        Debug.Log("Switched to EXPLORATION");
        map_gameobject = GameObject.Find("LocationBasedGame/Map");
        if(map_gameobject == null){
            Debug.Log("Cannot find map");
        }
        AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();
        List<TreeInfo> trees = TreeManager.GetTrees();
        Debug.Log("got here");

        foreach(TreeInfo tree in trees){
            Vector3 scene_position = amap.GeoToWorldPosition(tree.lat_long_coordinate);
            GameObject obj_to_spawn = TreeManager.treeDictionary[tree.tree_type];
            Debug.Log(tree.tree_type);

            float offsetX = Random.Range(-10, 10); // Example range for x-axis offset
            float offsetY = Random.Range(-1, 1); // Example range for y-axis offset
            float offsetZ = Random.Range(-10, 10); // Example range for z-axis offset

            // Create a random offset
            Vector3 randomOffset = new Vector3(offsetX, offsetY, offsetZ);

            // Add the random offset to the scene position
            scene_position += randomOffset;

            GameObject new_object = Instantiate(obj_to_spawn);
            Debug.Log(scene_position);
            Debug.Log(tree.lat_long_coordinate);
            new_object.transform.position = scene_position;

            float scaleFactor = tree.growth_percentage; // Or any other scale factor you prefer
            Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            new_object.transform.localScale = newScale;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        map_gameobject = GameObject.Find("LocationBasedGame/Map");
    }
}

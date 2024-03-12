using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine.SceneManagement;

public class TreeManager : MonoBehaviour
{
    public static Dictionary<string, GameObject> treeDictionary = new Dictionary<string, GameObject>();
    public static Dictionary<string, float> treeMoney = new Dictionary<string, float>();
    public static int num_squirrel = 0;

    public static TreeInfo nearestTree;

    public GameObject pine;
    public GameObject maple;
    public GameObject oak;
    public GameObject walnut;
    public GameObject chestnut;
    public GameObject coconut;
    public GameObject squirrel;
    static List<TreeInfo> trees = new List<TreeInfo>();
    // Start is called before the first frame update
    void Start()
    {
        treeDictionary.Add("pine", pine);
        treeDictionary.Add("maple", maple);
        treeDictionary.Add("oak", oak);
        treeDictionary.Add("walnut", walnut);
        treeDictionary.Add("chestnut", chestnut);
        treeDictionary.Add("coconut", coconut);
        treeDictionary.Add("squirrel", squirrel);

        treeMoney.Add("pine", 1f);
        treeMoney.Add("maple", 2f);
        treeMoney.Add("oak", 3f);
        treeMoney.Add("walnut", 4f);
        treeMoney.Add("chestnut", 5f);
        treeMoney.Add("coconut", 6f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (TreeInfo tree in trees)
        {
            tree.UpdateTree();
        }

        int randomNum = Random.Range(0, 1000);
        if(num_squirrel == 0 && trees.Count > 0 && randomNum < 2 && SceneManager.GetActiveScene().name == "exploration_scene")
        {
            int randomIndex = Random.Range(0, trees.Count);
            if(trees[randomIndex].growth_percentage<5.0) return;
            
            num_squirrel = 1;

            trees[randomIndex].has_squirrel = true;

            GameObject map_gameobject = GameObject.Find("LocationBasedGame/Map");
            AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();
            if (amap == null) Debug.Log("NO AMAP FOUND");
            Vector3 scene_position = trees[randomIndex].tree_obj.transform.position;

//amap.GeoToWorldPosition(trees[randomIndex].lat_long_coordinate);
            GameObject obj_to_spawn = treeDictionary["squirrel"];

            Vector3 offset = new Vector3(-15, 15, 0);
            scene_position += offset;
            GameObject new_object = Instantiate(obj_to_spawn);
            new_object.transform.position = scene_position;
            new_object.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

    }

    public static void createTree(string tree_type, Vector2d lat_long){
        trees.Add(
            new TreeInfo(tree_type, lat_long)
        );
    }

    public static List<TreeInfo> GetTrees(){
        return trees;
    }
}

public class TreeInfo
{
    public string tree_type;
    public GameObject tree_obj;
    public float growth_percentage = 1.0f;
    public Vector2d lat_long_coordinate;
    public bool has_squirrel = false;

    public TreeInfo(string _tree_type, Vector2d _lat_long){
        tree_type = _tree_type;
        lat_long_coordinate = _lat_long;
    }

    public void UpdateTree(){

        if(growth_percentage <= 5.0f){
            growth_percentage += 0.005f;
            

        } else {
            if (has_squirrel)
            {
                SeedManager.money += TreeManager.treeMoney[tree_type] * .001f;
            }
            else
            {
                SeedManager.money += TreeManager.treeMoney[tree_type];
            }
            
        }
        float scaleFactor = growth_percentage * .5f;
        Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        if(tree_obj){
            tree_obj.transform.localScale = newScale;

        }
    }
}
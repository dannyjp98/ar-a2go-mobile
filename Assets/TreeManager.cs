using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;

public class TreeManager : MonoBehaviour
{
    public static Dictionary<string, GameObject> treeDictionary = new Dictionary<string, GameObject>();
    public static Dictionary<string, float> treeMoney = new Dictionary<string, float>();
    HashSet<string> unlocked = new HashSet<string>();

    public static TreeInfo nearestTree;

    public GameObject pine;
    public GameObject maple;
    public GameObject oak;
    public GameObject walnut;
    public GameObject chestnut;
    public GameObject coconut;
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

        treeMoney.Add("pine", .010f);
        treeMoney.Add("maple", .020f);
        treeMoney.Add("oak", .030f);
        treeMoney.Add("walnut", .004f);
        treeMoney.Add("chestnut", .04f);
        treeMoney.Add("coconut", .06f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(TreeInfo tree in trees){
            tree.UpdateTree();
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

    public TreeInfo(string _tree_type, Vector2d _lat_long){
        tree_type = _tree_type;
        lat_long_coordinate = _lat_long;
    }

    public void UpdateTree(){

        if(growth_percentage <= 10.0f){
            growth_percentage += 0.0002f;
            float scaleFactor = growth_percentage;
            Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            if(tree_obj){
                tree_obj.transform.localScale = newScale;

            }

        } else {
            SeedManager.money += TreeManager.treeMoney[tree_type];
        }
    }
}
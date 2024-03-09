using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARObjectSpawner : MonoBehaviour
{
    public Transform cursor;
    public GameObject pine;
    public GameObject maple;

    public AudioClip spawn_sound_effect;

    public void SpawnAtCursor(GameObject obj)
    {
        GameObject new_object = Instantiate(obj);
        new_object.transform.SetPositionAndRotation(cursor.position, cursor.rotation);
        new_object.transform.localScale = new Vector3(.1f, .1f,.1f); // Replace xScale, yScale, zScale with desired scale values
        AudioSource.PlayClipAtPoint(spawn_sound_effect, Camera.main.transform.position);
    }

    public void SwitchModes()
    {
        SceneManager.LoadScene("exploration_scene");
    }

    void Start(){
        GameObject new_object = Instantiate(TreeManager.treeDictionary[TreeManager.nearestTree.tree_type]);
        float newsize = TreeManager.nearestTree.growth_percentage * 0.1f;
        new_object.transform.localScale = new Vector3(newsize, newsize, newsize);
    }
}




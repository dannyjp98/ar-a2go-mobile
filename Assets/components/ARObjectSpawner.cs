using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class ARObjectSpawner : MonoBehaviour
{
    public Transform cursor;
    public AudioClip spawn_sound_effect;
    public AudioClip acorn_spawn_noise;
    public GameObject squirrel_prefab;
    public void SpawnAtCursor(GameObject obj)
    {
        GameObject new_object = Instantiate(obj);
        new_object.transform.SetPositionAndRotation(cursor.position, cursor.rotation);
        new_object.transform.localScale = new Vector3(.1f, .1f,.1f); // Replace xScale, yScale, zScale with desired scale values
        AudioSource.PlayClipAtPoint(spawn_sound_effect, Camera.main.transform.position);
    }

    public void ShootObject(GameObject obj)
    {
        GameObject new_obj = Instantiate(obj);
        new_obj.transform.SetPositionAndRotation(Camera.main.transform.position, Camera.main.transform.rotation);

        new_obj.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 20;
        AudioSource.PlayClipAtPoint(acorn_spawn_noise, Camera.main.transform.position, 3f);
    }

    public void SwitchModes()
    {
        SceneManager.LoadScene("exploration_scene");
    }

    void Start(){
        GameObject new_object = Instantiate(TreeManager.treeDictionary[TreeManager.nearestTree.tree_type]);
        
        Vector3 newPos = Camera.main.transform.position + (Camera.main.transform.forward * 2);
        newPos.y = -1;
        new_object.transform.position = newPos;

        float newsize = 1f;
        
        new_object.transform.localScale = new Vector3(newsize, newsize, newsize);
        if (TreeManager.nearestTree.has_squirrel)
        {
            GameObject squirrel_obj = Instantiate(squirrel_prefab);
            squirrel_obj.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            squirrel_obj.transform.position = newPos + new Vector3(0f, 0f, -.5f);
            squirrel_obj.transform.Rotate(0, 180, 0);
        }


    }
}




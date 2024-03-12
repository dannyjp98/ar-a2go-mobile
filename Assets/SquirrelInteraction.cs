using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SquirrelInteraction : MonoBehaviour
{

    public float health;
    public AudioClip hit_sound;
    //public AudioClip squirrel_music;
    GameObject audioSourceObject;

    
    // Start is called before the first frame update
    void Start()
    {
        audioSourceObject = GameObject.Find("GameMusic");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health == 0)
        {
            GameObject.Destroy(gameObject);
            TreeManager.nearestTree.has_squirrel = false;
            TreeManager.num_squirrel = 0;
            return;
        }
        //AudioSource squirrel_audio = gameObject.GetComponent<AudioSource>();

        AudioSource game_music = GetComponent<AudioSource>();
        float dist = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
        audioSourceObject.SetActive(false);
        //AudioSource.PlayClipAtPoint(squirrel_music, Camera.main.transform.position);
        float newPositionX = gameObject.transform.position.x + .01f*Mathf.Sin(Time.time);

        // Update the GameObject's position
        gameObject.transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
                    Debug.Log("Hit object");


            if(collision.gameObject.tag == "acorn_obj")
        {
            Debug.Log("Hit squirrel");
            health -= 1;
            AudioSource.PlayClipAtPoint(hit_sound, Camera.main.transform.position);
            GameObject.Destroy(collision.gameObject);
            audioSourceObject.SetActive(true);

        }
    }
}

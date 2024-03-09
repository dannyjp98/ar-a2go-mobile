using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SquirrelInteraction : MonoBehaviour
{

    public float health;
    public AudioClip hit_sound;
    public AudioClip squirrel_music;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            GameObject.Destroy(gameObject);
            TreeManager.nearestTree.has_squirrel = false;
            TreeManager.num_squirrel = 0;
            return;
        }
        AudioSource squirrel_audio = gameObject.GetComponent<AudioSource>();
        AudioSource game_music = Camera.main.GetComponent<AudioSource>();
        float dist = Vector3.Distance(Camera.main.transform.position, gameObject.transform.position);
        if(dist < 1)
        { 
            game_music.Stop();
            AudioSource.PlayClipAtPoint(squirrel_music, Camera.main.transform.position);
            float newPositionX = gameObject.transform.position.x + Mathf.Sin(Time.time * 5);

            // Update the GameObject's position
            gameObject.transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
        else
        {
            squirrel_audio.Stop();
            game_music.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

            if(collision.gameObject.tag == "acorn")
        {
            health -= 1;
            AudioSource.PlayClipAtPoint(hit_sound, Camera.main.transform.position);
            GameObject.Destroy(collision.gameObject);
        }
    }
}

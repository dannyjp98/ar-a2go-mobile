using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class busbehavior : MonoBehaviour
{
    public AudioClip hit_sound;
    GameObject busPanel;


    public float moveSpeed = 5f; // Adjust as needed
    public float rotationSpeed = 9f; // Adjust as needed
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawned bus");
        busPanel = GameObject.Find("InfoCanvas/BusPanel");
        Debug.Log(busPanel);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotate the GameObject around its up axis (y-axis)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Hit object");

        if(collision.gameObject.tag == "player")
        {
            Debug.Log("Hit player");
            AudioSource.PlayClipAtPoint(hit_sound, Camera.main.transform.position, 2.0f);
            GameObject.Destroy(gameObject);
            SeedManager.money += 500;
            busPanel.transform.localScale = new Vector3(1f, 1f, 1f); // This will double the scale in all three axes

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playeranims : MonoBehaviour
{
    public Animator anim;
    public GameObject obj;
    Vector3 old_loc;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_loc = obj.transform.position;
        float diff = (current_loc - old_loc).magnitude;

        if (diff > 0.01f) // Adjust this threshold as needed
        {
            Vector3 direction = current_loc - old_loc;
            direction.y = 0f; // Ensure the rotation is only in the horizontal plane
            Quaternion rotation = Quaternion.LookRotation(direction);
            obj.transform.rotation = rotation;
        }
        
        anim.SetFloat("speed", diff);
        old_loc = current_loc;
    }
}

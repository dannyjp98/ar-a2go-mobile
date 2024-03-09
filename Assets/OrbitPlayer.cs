using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, 0.1f);
        if(Input.GetMouseButton(0)){
            //Debug.Log("holding left mouse button");
            float mouseX = Input.GetAxis("Mouse X"); // Get the horizontal movement of the mouse
            Debug.Log(Input.GetAxis("Mouse X"));
            float mouseY = Input.GetAxis("Mouse Y"); // Get the horizontal movement of the mouse

            transform.Rotate(-mouseY*3, mouseX*3, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
            transform.eulerAngles.y,
            0);
        }
    }
}

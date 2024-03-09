using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clickDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject infoPanel;
    public GameObject seedToUnlock;

    public Sprite newSprite;
    public Image uiImage;

    public string landmarkInfo;

    public Text landmarkText;


    void Start()
    {
        infoPanel.SetActive(false);
    }
    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this GameObject's collider
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // This GameObject was clicked
                OnClick();
            }
        }
    }
    void OnClick()
    {
        landmarkText.text = landmarkInfo;
        uiImage.sprite = newSprite;
        // Do something when this GameObject is clicked
        infoPanel.SetActive(true);
        seedToUnlock.SetActive(true);
    }

    public void hideInfo()
    {
        Debug.Log("hide info");
        infoPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clickDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject infoPanel;
    public GameObject busPanel;
    public GameObject player;
    public GameObject currLandmark;

    public GameObject seedToUnlock;

    public Sprite newSprite;
    public Image uiImage;

    public string landmarkInfo;

    public Text landmarkText;


    void Start()
    {
        player = GameObject.Find("PlayerTarget");
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
        player = GameObject.Find("PlayerTarget");

        if((player.transform.position - gameObject.transform.position).magnitude > 20f) return;
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

    public void hideInfoBus()
    {
        Debug.Log("hide info");
        busPanel.transform.localScale = new Vector3(0f, 1f, 1f); // This will double the scale in all three axes
    }
}

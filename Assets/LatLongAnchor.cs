using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class LatLongAnchor : MonoBehaviour
{

    public float latitude;
    public float longitude;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject map_gameobject = GameObject.Find("LocationBasedGame/Map");
        if(map_gameobject != null){
            AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();
            if(amap!=null){
                Vector3 scene_position = amap.GeoToWorldPosition(new Vector2d(latitude, longitude));
                transform.position = scene_position;
            }
        }
    }
}

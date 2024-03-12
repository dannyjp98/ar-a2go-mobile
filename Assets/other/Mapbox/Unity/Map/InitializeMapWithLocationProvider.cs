namespace Mapbox.Unity.Map
{
	using System.Collections;
	using Mapbox.Unity.Location;
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;


	public class InitializeMapWithLocationProvider : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		ILocationProvider _locationProvider;
    
		private void Awake()
		{
			// Prevent double initialization of the map. 
			_map.InitializeOnStart = false;
		}

		protected virtual IEnumerator Start()
		{
			yield return null;
			_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
			_locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated; ;
		}

		void LocationProvider_OnLocationUpdated(Unity.Location.Location location)
		{
			_locationProvider.OnLocationUpdated -= LocationProvider_OnLocationUpdated;
			_map.Initialize(location.LatitudeLongitude, _map.AbsoluteZoom);
			StartCoroutine(Example());

			
		}

		IEnumerator Example()
		{
			Debug.Log(Time.time);
			yield return new WaitForSeconds(0.5f);
			Debug.Log(Time.time);
			spawnstuff();
		}
		void spawnstuff(){

			List<TreeInfo> trees = TreeManager.GetTrees();
			foreach(TreeInfo tree in trees){
				GameObject map_gameobject = GameObject.Find("LocationBasedGame/Map");
				AbstractMap amap = map_gameobject.GetComponent<AbstractMap>();
				if(amap == null) Debug.Log("NO AMAP FOUND");
				Vector3 scene_position = amap.GeoToWorldPosition(tree.lat_long_coordinate);
				Debug.Log(tree.lat_long_coordinate);
				Debug.Log(scene_position);
				GameObject obj_to_spawn = TreeManager.treeDictionary[tree.tree_type];

				float offsetX = Random.Range(-10, 10); // Example range for x-axis offset
				float offsetY = Random.Range(-1, 1); // Example range for y-axis offset
				float offsetZ = Random.Range(-10, 10); // Example range for z-axis offset

				// Create a random offset
				Vector3 randomOffset = new Vector3(offsetX, offsetY, offsetZ);

				// Add the random offset to the scene position
				scene_position += randomOffset;

				GameObject new_object = Instantiate(obj_to_spawn);
				new_object.transform.position = scene_position;
                tree.tree_obj = new_object;

				float scaleFactor = tree.growth_percentage;
				Vector3 newScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
				new_object.transform.localScale = newScale;
				Debug.Log(tree);
				if (tree.has_squirrel)
				{
                    GameObject squirrel_obj = TreeManager.treeDictionary["squirrel"];

					Vector3 offset = new Vector3(-15, 15, 0);
                    GameObject squirrel = Instantiate(squirrel_obj);
					scene_position = tree.tree_obj.transform.position;

                    squirrel.transform.position = scene_position + offset;
                    squirrel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
			}
		}
	}
}

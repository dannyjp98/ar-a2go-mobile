namespace Mapbox.Unity.Location
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using Mapbox.Unity.Utilities;
	using Mapbox.Utils;
	using UnityEngine;
	using Mapbox.Unity.Map;


	/// <summary>
	/// <para>
	/// The EditorLocationProvider is responsible for providing mock location data via log file collected with the 'LocationProvider' scene
	/// </para>
	/// </summary>
	public class EditorLocationProviderLocationLog : AbstractEditorLocationProvider
	{


		/// <summary>
		/// The mock "latitude, longitude" location, respresented with a string.
		/// You can search for a place using the embedded "Search" button in the inspector.
		/// This value can be changed at runtime in the inspector.
		/// </summary>
		[SerializeField]
		private TextAsset _locationLogFile;


		private LocationLogReader _logReader;
		private IEnumerator<Location> _locationEnumerator;


#if UNITY_EDITOR
		protected override void Awake()
		{
			base.Awake();
			_logReader = new LocationLogReader(_locationLogFile.bytes);
			_locationEnumerator = _logReader.GetLocations();
		}
#endif


		private void OnDestroy()
		{
			if (null != _locationEnumerator)
			{
				_locationEnumerator.Dispose();
				_locationEnumerator = null;
			}
			if (null != _logReader)
			{
				_logReader.Dispose();
				_logReader = null;
			}
		}
		    public AbstractMap map; // Reference to your Mapbox map

		public static Vector2d current_player_position = new Vector2d(42.279594,-83.732124);
		float speed = 0.00003f;

		private void Update(){
			if(Input.GetKey(KeyCode.RightArrow)){
				current_player_position += new Vector2d(0, speed);
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				current_player_position += new Vector2d(0, -speed);
			}

			if(Input.GetKey(KeyCode.UpArrow)){
				current_player_position += new Vector2d(speed, 0);
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				current_player_position += new Vector2d(-speed,0);
			}
			

			Location new_location = new Location();
			new_location.LatitudeLongitude = current_player_position;
			
			_currentLocation = new_location;
			map.SetCenterLatitudeLongitude(current_player_position);


		}

		protected override void SetLocation()
		{
			// if (null == _locationEnumerator) { return; }

			// // no need to check if 'MoveNext()' returns false as LocationLogReader loops through log file
			// _locationEnumerator.MoveNext();
			// _currentLocation = _locationEnumerator.Current;
		}
	}
}

namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;




	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

    	[Header("ALL PREFABS")]
		[SerializeField]
		GameObject _playerPrefab;

		[SerializeField]
		GameObject _questionPrefab;

		[SerializeField]
		GameObject[] _artifacts;



		Vector2d[] _locations;
		List<GameObject> _spawnedObjects;



		void Start()
		{
			_locations = new Vector2d[_artifacts.Length];
			_spawnedObjects = new List<GameObject>();


			for (int i = 0; i < _artifacts.Length; i++) 
			{
				AddPrefabData properties = _artifacts[i].GetComponent<AddPrefabData>();

				if (properties != null)
				{
					string artifactLocation = properties.location;
					string artifactId = properties.id;


					_locations[i] = Conversions.StringToLatLon(artifactLocation);
					Vector3 objectPosition = _map.GeoToWorldPosition(_locations[i], true);


					var instance = Instantiate(_artifacts[i]);
					instance.transform.localPosition = new Vector3(objectPosition[0], _artifacts[i].transform.position.y, objectPosition[2]);

					_spawnedObjects.Add(instance);
				}
			}
		}


		private void Update()
		{
			for (int i = 0; i < _spawnedObjects.Count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];


				Vector3 objectPosition = _map.GeoToWorldPosition(location, true);
				spawnedObject.transform.localPosition = new Vector3(objectPosition[0], spawnedObject.transform.position.y, objectPosition[2]);
			}
		}
	}
}
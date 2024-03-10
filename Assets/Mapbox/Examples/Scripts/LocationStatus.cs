namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Utils;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class LocationStatus : MonoBehaviour
	{

		public Location currLoc;

		private AbstractLocationProvider _locationProvider = null;
		void Start()
		{
			if (null == _locationProvider)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
			}
		}


		void Update()
		{
			currLoc = _locationProvider.CurrentLocation;

			if (currLoc.IsLocationServiceInitializing)
			{}
			else
			{
				if (!currLoc.IsLocationServiceEnabled)
				{}
				else
				{
					if (currLoc.LatitudeLongitude.Equals(Vector2d.zero))
					{}
					else
					{}
				}
			}

		}


		public double GetLocationLat()
		{
			return currLoc.LatitudeLongitude.x;
		}

		
		public double GetLocationLon()
		{
			return currLoc.LatitudeLongitude.y;
		}
	}
}

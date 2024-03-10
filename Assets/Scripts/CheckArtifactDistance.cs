using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Examples;
using Mapbox.Utils;
using Mapbox.CheapRulerCs;


public class CheckArtifactDistance : MonoBehaviour
{
    [SerializeField] LocationStatus playerLocation;
    [SerializeField] GameObject gameManager;
    private GameObject[] artifacts;


    void Start()
    {
        SpawnOnMap properties = gameManager.GetComponent<SpawnOnMap>();
        artifacts = properties._artifacts;


        for (int i = 0; i < artifacts.Length; i++) 
        {
            string location = artifacts[i].GetComponent<AddPrefabData>().location;
            double[] a = new double[2];
            double[] b = new double[2];


            a[0] = playerLocation.GetLocationLat();
            a[1] = playerLocation.GetLocationLon();

            Debug.Log(a[0]);
            Debug.Log(a[1]);
        }
    }
}

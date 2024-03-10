using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Examples;
using TMPro;


public class RenderCollectedArtifacts : MonoBehaviour
{

    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject button;
    private GameObject[] artifacts;


    void Start()
    {
        SpawnOnMap properties = gameManager.GetComponent<SpawnOnMap>();
        artifacts = properties._artifacts;


        for (int i = 0; i < artifacts.Length; i++) 
        {
            Instantiate(button, this.transform);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;



public class Artifact
{
    public string name;
    public string id;
}


public class Achievement
{
    public string name;
    public string id;
}


public class Player
{
    public string username;
    public string email;
    public string createdAt;
    public List<Artifact> artifacts;
    public List<Achievement> achievements;
}




public class GameManager : MonoBehaviour
{
    public GameObject AuthMenu;
    public GameObject CityPicker;
    public GameObject NoInternet;


    void Start()
    {
        //PlayerPrefs.SetString("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJfaWQiOiI2NWViYTFlOTZjM2QxZWU5MTk3YjBkZDYiLCJpYXQiOjE3MDk5NDEyMjUsImV4cCI6MTcxMjUzMzIyNX0.9oCDXFDTmOI2X5gY0nS8dOfMiUu7B4_5tCO4Wl6EkIs");
        PlayerPrefs.SetString("token", "");
        string token = PlayerPrefs.GetString("token");


        if (token == "") {
            AuthMenu.SetActive(true);
            return;
        }


        checkNetworkConnection();
        StartCoroutine(GetUser(token));
    }



    private static async Task Wait()
    {
        await Task.Delay(1000);
    }




    private async void checkNetworkConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {

            NoInternet.SetActive(true);
            await Wait();
            checkNetworkConnection();
            return;
        }

        NoInternet.SetActive(false);
    }



    private IEnumerator GetUser(string token)
    {

        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/user");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + token);
        yield return request.SendWebRequest();



        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            checkNetworkConnection();
        }


        if (request.result == UnityWebRequest.Result.Success)
        {
            Player player = JsonConvert.DeserializeObject<Player>(request.downloadHandler.text);
            CityPicker.SetActive(true);
        }


        if (request.result != UnityWebRequest.Result.Success && request.result != UnityWebRequest.Result.ConnectionError)
        {
            AuthMenu.SetActive(true);
            PlayerPrefs.DeleteKey("token");
        }
    }
}

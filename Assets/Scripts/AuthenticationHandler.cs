using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;




public class HandleAuthentication : MonoBehaviour
{

    [Header("Login Inputs")]
    [SerializeField]
    GameObject loginEmail;

    [SerializeField]
    GameObject loginPassword;

    [SerializeField]
    GameObject loginError;


    [Header("Register Inputs")]
    [SerializeField]
    GameObject registerUsername;
    
    [SerializeField]
    GameObject registerEmail;

    [SerializeField]
    GameObject registerPassword;

    [SerializeField]
    GameObject registerError;



    public void Login()
    {
        StartCoroutine(LoginHandler());
    }


    public void Register()
    {
        StartCoroutine(RegisterHandler());
    }


    public void Logout()
    {
        StartCoroutine(LogoutHandler());
    }



    private IEnumerator LoginHandler()
    {
        Dictionary<string, string> body = new Dictionary<string, string>();
        body.Add("email", loginEmail.GetComponent<TMP_InputField>().text);
        body.Add("password", loginPassword.GetComponent<TMP_InputField>().text);


        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/login", JsonConvert.SerializeObject(body), "application/json");
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            loginError.GetComponent<TMP_Text>().text = "Invalid Credentials!";
        }
        else
        {
            // string token = JsonConvert.DeserializeObject(request.downloadHandler.text).token;
            // Debug.Log(token);
        }
    }



    private IEnumerator RegisterHandler()
    {
        Dictionary<string, string> body = new Dictionary<string, string>();
        body.Add("username", registerUsername.GetComponent<TMP_InputField>().text);
        body.Add("email", registerEmail.GetComponent<TMP_InputField>().text);
        body.Add("password", registerPassword.GetComponent<TMP_InputField>().text);


        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/register", JsonConvert.SerializeObject(body), "application/json");
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            registerError.GetComponent<TMP_Text>().text = "Invalid Credentials!";
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
        }
    }




    private IEnumerator LogoutHandler()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:8080/logout");
        yield return request.SendWebRequest();


        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            PlayerPrefs.DeleteKey("token");
        }
    }

}

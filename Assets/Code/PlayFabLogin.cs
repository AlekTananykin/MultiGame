using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    public Action<string, bool> OnLogin;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "25BB3";
        }

        var request = new LoginWithCustomIDRequest { 
            CustomId = "Lesson3Player" , CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        var errorMessage = error.GenerateErrorReport();
        string msg = $"Error: {errorMessage}";
        Debug.Log(msg);
        OnLogin(msg, false);
    }

    private void OnLoginSuccess(LoginResult obj)
    {
        Debug.Log("Login Success");
        OnLogin("Login Success", true);
    }
}

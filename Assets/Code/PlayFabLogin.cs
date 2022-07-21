using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
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

        Debug.Log($"Error: {errorMessage}");
    }

    private void OnLoginSuccess(LoginResult obj)
    {
        Debug.Log("Login Success");
    }
}

using PlayFab.ClientModels;
using System;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayFabView : MonoBehaviour
{
    [SerializeField] 
    private PlayFabLogin _playfabLogin;

    [SerializeField] 
    private TextMeshProUGUI _text;

    void Start()
    {
        _playfabLogin.OnLogin += Login;
    }

    private void OnDestroy()
    {
        _playfabLogin.OnLogin -= Login;
    }

    public void Login(string message, bool isSuccess) 
    {
        if (isSuccess)
        {
            _text.text = message.ToString();
            _text.color = Color.green;
        }
        else
        {
            StringBuilder failMessage = new StringBuilder("Login is Failed");
            failMessage.Append(message);
            _text.text = failMessage.ToString();
            _text.color = Color.red;
            _text.fontSize = 10;
        }
    }
}

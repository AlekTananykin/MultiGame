using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountWindowBase : MonoBehaviour
{
    [SerializeField]
    private InputField _usernameField;

    [SerializeField]
    private InputField _passwordField;

    protected string _username;
    protected string _password;

    void Start()
    {
        SubscriptionElementUi();
    }

    private void OnDestroy()
    {
        UnsubscribeElementUi();
    }

    protected virtual void SubscriptionElementUi()
    {
        _usernameField.onValueChanged.AddListener(UpdateUsername);
        _passwordField.onValueChanged.AddListener(UpdatePassword);
    }

    protected virtual void UnsubscribeElementUi()
    {
        _usernameField.onValueChanged.RemoveAllListeners();
        _passwordField.onValueChanged.RemoveAllListeners();
    }

    private void UpdatePassword(string password)
    {
        _password = password;
    }

    private void UpdateUsername(string username)
    {
        _username = username;
    }


}

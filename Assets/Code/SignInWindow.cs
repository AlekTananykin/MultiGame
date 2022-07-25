using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class SignInWindow : AccountWindowBase
{
    [SerializeField]
    private Button _createAccountButton;

    protected override void SubscriptionElementUi()
    {
        base.SubscriptionElementUi();
        _createAccountButton.onClick.AddListener(SignIn);
    }

    protected override void UnsubscribeElementUi()
    {
        base.UnsubscribeElementUi();
        _createAccountButton.onClick.RemoveAllListeners();
    }

    private void SignIn()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest { 
            Username = _username,
            Password = _password
        }
        , result => { Debug.Log($"Success: {_username}"); }
        , error => { Debug.LogError($"Fail: {error.ErrorMessage}"); }
        );
    }
}

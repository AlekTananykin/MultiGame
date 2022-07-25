using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class CreateAccountWindow : AccountWindowBase
{
    [SerializeField]
    private InputField _emailField;

    [SerializeField]
    private Button _createAccountButton;

    private string _email;

    protected override void SubscriptionElementUi()
    {
        base.SubscriptionElementUi();
        _emailField.onValueChanged.AddListener(UpdateEmail);
        _createAccountButton.onClick.AddListener(CreateAccount);
    }

    protected override void UnsubscribeElementUi()
    {
        base.UnsubscribeElementUi();
        _emailField.onValueChanged.RemoveAllListeners();
        _createAccountButton.onClick.RemoveAllListeners();
    }


    private void UpdateEmail(string email)
    {
        _email = email;
    }

    private void CreateAccount()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest
        {
            Username = _username,
            Email = _email,
            Password = _password
        }
        , result => { Debug.Log($"Success: {_username}"); }
        , error => {Debug.LogError($"Fail: {error.ErrorMessage}");});
    }
}

using UnityEngine;
using UnityEngine.UI;

public sealed class EnterInGameWindow : MonoBehaviour
{
    [SerializeField]
    private Button _signInButton;

    [SerializeField]
    private Button _createAccountButton;

    [SerializeField]
    private Canvas _enterInGameCanvas;

    [SerializeField]
    private Canvas _createAccountCanvas;

    [SerializeField]
    private Canvas _signInCanvas;


    void Start()
    {
        _signInButton.onClick.AddListener(OpenSignInWindow);
        _createAccountButton.onClick.AddListener(OpenCreateAccountWindow);

        _enterInGameCanvas.enabled = true;
    }

    private void OnDestroy()
    {
        _signInButton.onClick.RemoveAllListeners();
        _createAccountButton.onClick.RemoveAllListeners();
    }

    private void OpenCreateAccountWindow()
    {
        _createAccountCanvas.enabled = true;
        _signInCanvas.enabled = false;
       // _enterInGameCanvas.enabled = false;
    }

    private void OpenSignInWindow()
    {
        _signInCanvas.enabled = true;
        //_enterInGameCanvas.enabled = false;
        _createAccountCanvas.enabled = false;
    }
}

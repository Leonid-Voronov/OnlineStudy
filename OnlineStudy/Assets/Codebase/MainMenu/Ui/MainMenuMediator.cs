using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuMediator : MonoBehaviour
{
    [SerializeField] private Button _connectToServerButton;
    [SerializeField] private Button _accountButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private GameObject _emptyProfilePopUp;

    private INetworkConnector _networkConnector;
    private IApplicationQuitter _applicationQuitter;

    [Inject]
    public void Construct(INetworkConnector networkConnector, IApplicationQuitter applicationQuitter)
    {
        _networkConnector = networkConnector;
        _applicationQuitter = applicationQuitter;
    }
    
    private void Start()
    {
        //Ui=>Logic
        _connectToServerButton.onClick.AddListener(ConnectToServer);
        _quitButton.onClick.AddListener(Quit);
        
        //Logic=>Ui
        _networkConnector.OnEmptyProfileConnectionCancel += ShowEmptyProfilePopUp;
    }

    private void OnDestroy()
    {
        //Ui=>Logic
        _connectToServerButton.onClick.RemoveListener(ConnectToServer);
        _quitButton.onClick.RemoveListener(Quit);
        
        //Logic=>Ui
        _networkConnector.OnEmptyProfileConnectionCancel -= ShowEmptyProfilePopUp;
    }

    private void ConnectToServer() => _networkConnector.ConnectToNetwork();
    
    private void Quit() => _applicationQuitter.QuitApplication();
    
    private void ShowEmptyProfilePopUp(object sender, EventArgs eventArgs) => _emptyProfilePopUp.SetActive(true);
}

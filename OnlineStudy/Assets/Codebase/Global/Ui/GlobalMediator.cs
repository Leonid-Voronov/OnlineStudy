using System;
using UnityEngine;
using Zenject;

public class GlobalMediator : MonoBehaviour
{
    private IUiRegistry _uiRegistry;
    private INetworkConnector _networkConnector;

    [Inject]
    public void Construct(IUiRegistry uiRegistry, INetworkConnector networkConnector)
    {
        _uiRegistry = uiRegistry;
        _networkConnector = networkConnector;
    }

    private void Start()
    {
        _networkConnector.OnLobbyJoined += ShowNetworkUi;
        _networkConnector.Disconnected += ShowMainMenuUi;
    }

    private void OnDestroy()
    {
        _networkConnector.OnLobbyJoined -= ShowNetworkUi;
        _networkConnector.Disconnected -= ShowMainMenuUi;
    }
    
    private void ShowNetworkUi(object sender, EventArgs eventArgs) => _uiRegistry.ShowNetworkUi();
    
    private void ShowMainMenuUi(object sender, EventArgs eventArgs) => _uiRegistry.ShowMainMenuUi();
}

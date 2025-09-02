using UnityEngine;
using Zenject;

public class NetworkUiInitializer: INetworkUiInitializer
{
    private const string NetworkUiKey = "NetworkUi";
    
    private readonly IGlobalGameFactory _globalGameFactory;
    private readonly UiParentLink _uiParentLink;
    private readonly IUiRegistry _uiRegistry;
    
    [Inject]
    public NetworkUiInitializer(IGlobalGameFactory globalGameFactory, 
                                UiParentLink uiParentLink, 
                                IUiRegistry uiRegistry)
    {
        _globalGameFactory = globalGameFactory;
        _uiParentLink = uiParentLink;
        _uiRegistry = uiRegistry;
    }
    
    public void InitializeNetworkUi()
    {
        GameObject networkUi = _globalGameFactory.CreateNetworkUi(_uiParentLink.transform);
        _uiRegistry.RegisterUI(NetworkUiKey, networkUi);
    }
}
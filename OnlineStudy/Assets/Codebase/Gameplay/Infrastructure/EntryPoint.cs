using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private IMainMenuUiInitializer _mainMenuUiInitializer;
    private INetworkUiInitializer _networkUiInitializer;
    private ILoadingCurtainService _loadingCurtainService;
    private IUiRegistry _uiRegistry;
    

    [Inject]
    public void Construct(IMainMenuUiInitializer mainMenuUiInitializer, 
                          INetworkUiInitializer networkUiInitializer,
                          ILoadingCurtainService loadingCurtainService,
                          IUiRegistry uiRegistry)
    {
        _mainMenuUiInitializer = mainMenuUiInitializer;
        _networkUiInitializer = networkUiInitializer;
        _loadingCurtainService = loadingCurtainService;
        _uiRegistry = uiRegistry;
    }
    
    private void Start()
    {
        _networkUiInitializer.InitializeNetworkUi();
        _mainMenuUiInitializer.InitializeMainMenu();
        _uiRegistry.ShowMainMenuUi();
        _loadingCurtainService.ShowLoadingCurtain(false);
    }
}

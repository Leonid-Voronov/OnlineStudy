using UnityEngine;
using Zenject;

public class MainMenuUiInitializer : IMainMenuUiInitializer
{
    private const string MainMenuKey = "MainMenu";
    
    private readonly IGlobalGameFactory _globalGameFactory;
    private readonly UiParentLink _uiParentLink;
    private readonly IUiRegistry _uiRegistry;

    [Inject]
    public MainMenuUiInitializer(IGlobalGameFactory globalGameFactory, 
                                 UiParentLink uiParentLink, 
                                 IUiRegistry uiRegistry)
    {
        _globalGameFactory = globalGameFactory;
        _uiParentLink = uiParentLink;
        _uiRegistry = uiRegistry;
    }
    
    public GameObject InitializeMainMenu()
    {
        GameObject mainMenuUi = _globalGameFactory.CreateMainMenu(_uiParentLink.transform);
        _uiRegistry.RegisterUI(MainMenuKey, mainMenuUi);
        return mainMenuUi;
    }
}
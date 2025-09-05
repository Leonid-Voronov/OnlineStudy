using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    [Header("Scene references")]
    [SerializeField] private UiParentLink _uiParentLink;
    [SerializeField] private MainMenuCameraTag _cameraTag;
    
    public override void InstallBindings()
    {
        InstallFactories();
        InstallUi();
        InstallCamera();
    }

    private void InstallCamera()
    {
        Container.Bind<MainMenuCameraTag>()
            .FromInstance(_cameraTag)
            .AsSingle();

        Container.BindInterfacesTo<MainMenuCameraDisabler>()
            .AsSingle();
    }

    private void InstallFactories()
    {
        Container.Bind<IGameplayUiFactory>()
            .To<GameplayUiFactory>()
            .AsSingle();
    }

    private void InstallUi()
    {
        Container.Bind<IGameplayUiInitializer>()
            .To<GameplayUiInitializer>()
            .AsSingle();
        
        Container.Bind<UiParentLink>()
            .FromInstance(_uiParentLink)
            .AsSingle();
        
        Container.Bind<INetworkUiInitializer>()
            .To<NetworkUiInitializer>()
            .AsSingle();
        
        Container.Bind<IMainMenuUiInitializer>()
            .To<MainMenuUiInitializer>()
            .AsSingle();
    }
}

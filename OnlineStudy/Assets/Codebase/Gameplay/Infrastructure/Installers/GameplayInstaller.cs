using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [Header("Scene references")]
    [SerializeField] private UiParentLink _uiParentLink;
    
    public override void InstallBindings()
    {
        InstallFactories();
        InstallUi();
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

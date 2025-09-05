using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("Scriptable objects")]
    [SerializeField] private TextLibrarySo _textLibrarySo;
    [SerializeField] private MultiplayerConfigSo _multiplayerConfigSo;
    
    public override void InstallBindings()
    {
        InstallTextEntries();
        InstallNetworkBindings();
        InstallResourcesBindings();
        InstallFactoryBindings();
        InstallUiBindings();
        InstallLifeCycleBindings();
    }

    private void InstallLifeCycleBindings()
    {
        Container.Bind<ISceneLoadService>()
            .To<SceneLoadService>()
            .AsSingle();
        
        Container.Bind<IApplicationQuitter>()
            .To<ApplicationQuitter>()
            .AsSingle();
    }

    private void InstallUiBindings()
    {
        Container.BindInterfacesTo<LoadingCurtainService>()
            .AsSingle();
        
        Container.BindInterfacesTo<UiRegistry>()
            .AsSingle();
    }

    private void InstallFactoryBindings()
    {
        Container.Bind<IGlobalGameFactory>()
            .To<GlobalGameFactory>()
            .AsSingle();
    }

    private void InstallResourcesBindings()
    {
        Container.Bind<IResourcesService>()
            .To<ResourcesService>()
            .AsSingle();
    }

    private void InstallNetworkBindings()
    {
        Container.Bind<INetworkConnector>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.Bind<IRoomConnector>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.Bind<PlayerJoinObserver>()
            .FromComponentInHierarchy()
            .AsSingle();
        
        Container.Bind<MultiplayerConfigSo>()
            .FromInstance(_multiplayerConfigSo)
            .AsSingle();
        
        Container.BindInterfacesTo<RoomPlayersInfoService>()
            .AsSingle();
        
        Container.BindInterfacesTo<AccountService>()
            .AsSingle();
    }
    
    private void InstallTextEntries()
    {
        Container.Bind<TextLibrarySo>()
            .FromInstance(_textLibrarySo)
            .AsSingle();
        
        Container.Bind<ITextEntriesService>()
            .To<TextLibraryEntriesService>()
            .AsSingle();
    }
}

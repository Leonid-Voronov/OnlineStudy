using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private CharacterSpawnPoint _characterSpawnPoint;
    
    public override void InstallBindings()
    {
        InstallFactories();
        InstallSceneReferences();
        InstallInputBindings();
    }

    private void InstallFactories()
    {
        Container.Bind<IGameplayFactory>()
            .To<GameplayFactory>()
            .AsSingle();
    }

    private void InstallSceneReferences()
    {
        Container.Bind<CharacterSpawnPoint>()
            .FromInstance(_characterSpawnPoint)
            .AsSingle();
    }

    private void InstallInputBindings()
    {
        Container.Bind<PlayerInput>()
            .To<PlayerInput>()
            .AsSingle();
        
        Container.BindInterfacesTo<GameplayInputService>()
            .AsSingle();
    }
}

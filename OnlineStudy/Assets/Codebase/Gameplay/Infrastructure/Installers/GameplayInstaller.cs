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
}

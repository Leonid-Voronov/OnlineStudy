using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private const string SceneName = "TestEnvironment";
    
    private IGameplayFactory _gameplayFactory;
    private CharacterSpawnPoint _characterSpawnPoint;

    [Inject]
    public void Construct(IGameplayFactory gameplayFactory, CharacterSpawnPoint characterSpawnPoint)
    {
        _gameplayFactory = gameplayFactory;
        _characterSpawnPoint = characterSpawnPoint;
    }
    
    private void Start()
    {
        _gameplayFactory.CreatePlayer(SceneName, _characterSpawnPoint.transform.position);
    }
}

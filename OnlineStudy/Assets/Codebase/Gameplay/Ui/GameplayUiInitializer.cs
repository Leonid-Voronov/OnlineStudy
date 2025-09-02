using UnityEngine;
using Zenject;

public class GameplayUiInitializer : IGameplayUiInitializer
{
    private readonly IGameplayUiFactory _gameplayUiFactory;

    [Inject]
    public GameplayUiInitializer(IGameplayUiFactory gameplayUiFactory)
    {
        _gameplayUiFactory = gameplayUiFactory;
    }
    
    public void InitializeGameplayUi()
    {
        _gameplayUiFactory.CreateGameplayUi();
    }
}
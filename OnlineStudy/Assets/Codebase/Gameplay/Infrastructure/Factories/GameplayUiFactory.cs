using Zenject;

public class GameplayUiFactory : IGameplayUiFactory
{
    private const string GameplayUiPath = "Ui/GameplayUi";

    private readonly IResourcesService _resourcesService;
    private readonly DiContainer _diContainer;
    
    [Inject]
    public GameplayUiFactory(IResourcesService resourcesService, DiContainer diContainer)
    {
        _resourcesService = resourcesService;
        _diContainer = diContainer;
    }
    
    public GameplayUiMediator CreateGameplayUi()
        => _diContainer.InstantiatePrefabForComponent<GameplayUiMediator>(_resourcesService.GetPrefab(GameplayUiPath));
}
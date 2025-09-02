using UnityEngine;
using Zenject;

public class GlobalGameFactory : IGlobalGameFactory
{
    private const string LoadingCurtainPath = "Ui/LoadingCurtain";
    private const string NetworkUiPath = "Ui/NetworkUi";
    private const string MainMenuPath = "Ui/MainMenu";
    
    private readonly DiContainer _diContainer;
    
    [Inject]
    public GlobalGameFactory(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public LoadingCurtainDisplay CreateLoadingCurtain() =>
        _diContainer.InstantiatePrefabResourceForComponent<LoadingCurtainDisplay>(LoadingCurtainPath);

    public GameObject CreateNetworkUi(Transform parent)
        => _diContainer.InstantiatePrefabResource(NetworkUiPath, parent);
    
    public GameObject CreateMainMenu(Transform parent) 
        => _diContainer.InstantiatePrefabResource(MainMenuPath, parent);

    public RoomPlayersInfo CreateRoomPlayersInfo() 
        => _diContainer.Instantiate<RoomPlayersInfo>();
}
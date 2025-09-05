using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RoomMediator : MonoBehaviour
{
    [SerializeField] private Button _quitRoomButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private PlayersDisplayPanel _playersDisplayPanel;
    private IRoomConnector _roomConnector;
    private IRoomPlayersInfoService _roomPlayersInfoService;
    private ISceneLoadService _sceneLoadService;
    private IUiHider _uiHider;

    [Inject]
    public void Construct(IRoomConnector roomConnector, 
                          IRoomPlayersInfoService roomPlayersInfoService, 
                          ISceneLoadService sceneLoadService,
                          IUiHider uiHider)
    {
        _roomConnector = roomConnector;
        _roomPlayersInfoService = roomPlayersInfoService;
        _sceneLoadService = sceneLoadService;
        _uiHider = uiHider;
    }

    private void OnEnable()
    {
        _playersDisplayPanel.DisplayPlayersData(_roomPlayersInfoService.RoomPlayersInfo);
    }

    private void Start()
    {
        _quitRoomButton.onClick.AddListener(QuitRoom);
        _startGameButton.onClick.AddListener(LoadGameScene);
        _roomPlayersInfoService.PlayersInfoUpdated += DisplayPlayersInfo;
    }

    private void OnDestroy()
    {
        _quitRoomButton.onClick.RemoveListener(QuitRoom);
        _startGameButton.onClick.RemoveListener(LoadGameScene);
        _roomPlayersInfoService.PlayersInfoUpdated -= DisplayPlayersInfo;
    }

    private void QuitRoom() => _roomConnector.LeaveRoom();

    private void DisplayPlayersInfo(object sender, EventArgs eventArgs) 
        => _playersDisplayPanel.DisplayPlayersData(_roomPlayersInfoService.RoomPlayersInfo);

    private void LoadGameScene()
    {
        _uiHider.HideCurrentUi();
        _sceneLoadService.LoadTestEnvironment();
    }
}

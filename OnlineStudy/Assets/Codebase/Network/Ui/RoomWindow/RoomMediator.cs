using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RoomMediator : MonoBehaviour
{
    [SerializeField] private Button _quitRoomButton;
    [SerializeField] private PlayersDisplayPanel _playersDisplayPanel;
    private IRoomConnector _roomConnector;
    private IRoomPlayersInfoService _roomPlayersInfoService;

    [Inject]
    public void Construct(IRoomConnector roomConnector, IRoomPlayersInfoService roomPlayersInfoService)
    {
        _roomConnector = roomConnector;
        _roomPlayersInfoService = roomPlayersInfoService;
    }

    private void Start()
    {
        _quitRoomButton.onClick.AddListener(QuitRoom);
        _roomPlayersInfoService.PlayersInfoUpdated += DisplayPlayersInfo;

        _playersDisplayPanel.DisplayPlayersData(_roomPlayersInfoService.RoomPlayersInfo);
    }

    private void OnDestroy()
    {
        _quitRoomButton.onClick.RemoveListener(QuitRoom);
        _roomPlayersInfoService.PlayersInfoUpdated -= DisplayPlayersInfo;
    }

    private void QuitRoom() => _roomConnector.LeaveRoom();

    private void DisplayPlayersInfo(object sender, EventArgs eventArgs) 
        => _playersDisplayPanel.DisplayPlayersData(_roomPlayersInfoService.RoomPlayersInfo);
}

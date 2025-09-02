using System;
using UnityEngine;
using Zenject;

public class NetworkUiMediator : MonoBehaviour
{
    [SerializeField] private GameObject _joinRoomWindow;
    [SerializeField] private GameObject _roomWindow;

    private INetworkConnector _networkConnector;
    private IRoomConnector _roomConnector;

    [Inject]
    private void Construct(INetworkConnector networkConnector, IRoomConnector roomConnector)
    {
        _networkConnector = networkConnector;
        _roomConnector = roomConnector;
    }
    
    private void Start()
    {
        _roomConnector.RoomJoined += HideJoinRoomWindow;
        _roomConnector.RoomJoined += ShowRoomWindow;
        _roomConnector.RoomLeft += HideRoomWindow;
        _roomConnector.RoomLeft += ShowJoinRoomWindow;
        
        ShowJoinRoomWindow();
    }

    private void OnDestroy()
    {
        _roomConnector.RoomJoined -= HideJoinRoomWindow;
        _roomConnector.RoomJoined -= ShowRoomWindow;
        _roomConnector.RoomLeft -= HideRoomWindow;
        _roomConnector.RoomLeft -= ShowJoinRoomWindow;
    }

    private void ShowJoinRoomWindow(object sender, EventArgs eventArgs) => ShowJoinRoomWindow();
    private void ShowJoinRoomWindow() => _joinRoomWindow.SetActive(true);
    private void HideJoinRoomWindow(object sender, EventArgs eventArgs) => _joinRoomWindow.SetActive(false);
    private void ShowRoomWindow(object sender, EventArgs eventArgs) => _roomWindow.SetActive(true);
    private void HideRoomWindow(object sender, EventArgs eventArgs) => _roomWindow.SetActive(false);
}

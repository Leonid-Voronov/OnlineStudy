using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

public class RoomPlayersInfoService : IInitializable, IDisposable, IRoomPlayersInfoService
{
    public event EventHandler PlayersInfoUpdated;
    
    private readonly IRoomConnector _roomConnector;
    private readonly IGlobalGameFactory _globalGameFactory;
    private readonly PlayerJoinObserver _playerJoinObserver;
    
    public RoomPlayersInfo RoomPlayersInfo => _roomPlayersInfo;
    
    private RoomPlayersInfo _roomPlayersInfo;

    [Inject]
    public RoomPlayersInfoService(IRoomConnector roomConnector, 
                                  IGlobalGameFactory globalGameFactory, 
                                  PlayerJoinObserver playerJoinObserver)
    {
        _roomConnector = roomConnector;
        _globalGameFactory = globalGameFactory;
        _playerJoinObserver = playerJoinObserver;
    }
    
    public void Initialize()
    {
        _roomConnector.RoomJoined += CreatePlayersInfo;
        _roomConnector.RoomLeft += DestroyPlayersInfo;
        _playerJoinObserver.RoomPlayerJoined += UpdatePlayersInfo;
        _playerJoinObserver.RoomPlayerLeft += UpdatePlayersInfo;
    }

    public void Dispose()
    {
        _roomConnector.RoomJoined -= CreatePlayersInfo;
        _roomConnector.RoomLeft -= DestroyPlayersInfo;
        _playerJoinObserver.RoomPlayerJoined -= UpdatePlayersInfo;
        _playerJoinObserver.RoomPlayerLeft -= UpdatePlayersInfo;
    }

    private void CreatePlayersInfo(object sender, EventArgs eventArgs) 
        => _roomPlayersInfo = _globalGameFactory.CreateRoomPlayersInfo();

    private void UpdatePlayersInfo(object sender, Player player)
    {
        _roomPlayersInfo.UpdatePlayersInfo();
        PlayersInfoUpdated?.Invoke(this, EventArgs.Empty);
    }

    private void DestroyPlayersInfo(object sender, EventArgs eventArgs) 
        => _roomPlayersInfo = null;
}
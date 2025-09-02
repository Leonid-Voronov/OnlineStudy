using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

public class RoomConnector : MonoBehaviourPunCallbacks, IRoomConnector
{
    public event EventHandler RoomJoined;
    public event EventHandler RoomJoinFailed;
    public event EventHandler RoomLeft;
    
    private MultiplayerConfigSo _multiplayerConfigSo;

    [Inject]
    public void Construct(MultiplayerConfigSo multiplayerConfigSo)
    {
        _multiplayerConfigSo = multiplayerConfigSo;
    }

    public void AttemptRoomConnection()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = _multiplayerConfigSo.MaxPlayersPerRoom;
        PhotonNetwork.JoinOrCreateRoom("MyRoom", options, TypedLobby.Default);
        Debug.Log("Start connecting room");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Leave room");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        RoomJoined?.Invoke(this, EventArgs.Empty);
        Debug.Log("Room Joined");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        RoomJoinFailed?.Invoke(this, EventArgs.Empty);
        Debug.Log("Room Join failed");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        RoomLeft?.Invoke(this, EventArgs.Empty);
        Debug.Log("Room Left");
    }
}
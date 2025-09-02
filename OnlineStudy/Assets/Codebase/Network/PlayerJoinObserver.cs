using System;
using Photon.Pun;
using Photon.Realtime;

public class PlayerJoinObserver : MonoBehaviourPunCallbacks
{
    public event EventHandler<Player> RoomPlayerJoined;
    public event EventHandler<Player> RoomPlayerLeft;
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        RoomPlayerJoined?.Invoke(this, newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        RoomPlayerLeft?.Invoke(this, otherPlayer);
    }
}

using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomPlayersInfo
{
    public IReadOnlyList<Player> Players => players;
    private List<Player> players;
    
    public RoomPlayersInfo()
    {
        players = new List<Player>();
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            players.Add(player);
        }
    }

    public void UpdatePlayersInfo()
    {
        players.Clear();
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            players.Add(player);
        }
    }
}

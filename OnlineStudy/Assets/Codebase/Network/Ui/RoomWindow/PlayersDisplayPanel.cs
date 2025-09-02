using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayersDisplayPanel : MonoBehaviour
{
    [SerializeField] private List<PlayerDataDisplay> playerDisplays = new();
    
    public void DisplayPlayersData(RoomPlayersInfo roomPlayersInfo)
    {
        for (int i = 0; i < playerDisplays.Count; i++)
        {
            playerDisplays[i].gameObject.SetActive(i < roomPlayersInfo.Players.Count);

            if (playerDisplays[i].gameObject.activeInHierarchy)
            {
                playerDisplays[i].DisplayNickname(roomPlayersInfo.Players[i].NickName);
            }
        }
    }
}

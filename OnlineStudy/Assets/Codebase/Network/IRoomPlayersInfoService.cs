using System;

public interface IRoomPlayersInfoService
{
    public event EventHandler PlayersInfoUpdated;
    
    public RoomPlayersInfo RoomPlayersInfo { get; }
}
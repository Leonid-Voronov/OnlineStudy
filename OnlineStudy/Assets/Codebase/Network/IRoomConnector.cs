using System;

public interface IRoomConnector
{
    public event EventHandler RoomJoined;
    public event EventHandler RoomJoinFailed;
    public event EventHandler RoomLeft;
    
    public void AttemptRoomConnection();
    public void LeaveRoom();
}
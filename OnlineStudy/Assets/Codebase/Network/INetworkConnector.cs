using System;

public interface INetworkConnector
{
    public event EventHandler OnConnectionAttempt;
    public event EventHandler OnLobbyJoinAttempt;
    public event EventHandler OnEmptyProfileConnectionCancel;
    public event EventHandler OnLobbyJoined;
    public event EventHandler Disconnected;
    
    public void ConnectToNetwork();
    public void DisconnectFromNetwork();
}
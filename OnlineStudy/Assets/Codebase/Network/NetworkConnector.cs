using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

public class NetworkConnector: MonoBehaviourPunCallbacks, INetworkConnector
{
    public event EventHandler OnConnectionAttempt;
    public event EventHandler OnLobbyJoinAttempt;
    public event EventHandler OnEmptyProfileConnectionCancel;
    public event EventHandler OnLobbyJoined;
    public event EventHandler Disconnected;

    private ILoadingCurtainService _loadingCurtainService;
    private IAccountService _accountService;

    [Inject]
    public void Construct(ILoadingCurtainService loadingCurtainService, IAccountService accountService)
    {
        _loadingCurtainService = loadingCurtainService;
        _accountService = accountService;
    }
    
    public void ConnectToNetwork()
    {
        if (!_accountService.IsNicknameSet)
        {
            OnEmptyProfileConnectionCancel?.Invoke(this, EventArgs.Empty);
            return;
        }
        
        _loadingCurtainService.ShowLoadingCurtain(true);
        Debug.Log("Attempting to connect to master server");
        OnConnectionAttempt?.Invoke(this, EventArgs.Empty);
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public void DisconnectFromNetwork()
    {
        _loadingCurtainService.ShowLoadingCurtain(true);
        Debug.Log("Attempting to disconnect");
        PhotonNetwork.LeaveLobby();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        OnLobbyJoinAttempt?.Invoke(this, EventArgs.Empty);
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        OnLobbyJoined?.Invoke(this, EventArgs.Empty);
        StartCoroutine(HideLoadingCurtainWithDelay());
        Debug.Log("Joined lobby");
    }

    public override void OnLeftLobby() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        Disconnected?.Invoke(this, EventArgs.Empty);
        StartCoroutine(HideLoadingCurtainWithDelay());
    }

    private IEnumerator HideLoadingCurtainWithDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        _loadingCurtainService.ShowLoadingCurtain(false);
    }
}
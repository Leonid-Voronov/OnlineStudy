using System;
using TMPro;
using UnityEngine;
using Zenject;

public class LoadingCurtainDisplay : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TMP_Text _text;

    [Header("Values")] 
    [SerializeField] private string _connectionAttemptKey;
    [SerializeField] private string _joinLobbyAttemptKey;
    [SerializeField] private string _joinLobbyKey;
    
    private INetworkConnector _networkConnector;
    private ITextEntriesService _textEntriesService;

    [Inject]
    public void Construct(INetworkConnector networkConnector, ITextEntriesService textEntriesService)
    {
        _networkConnector = networkConnector;
        _textEntriesService = textEntriesService;
    }
    
    private void Start()
    {
        _networkConnector.OnConnectionAttempt += DisplayConnectionAttempt;
        _networkConnector.OnLobbyJoinAttempt += DisplayJoinLobbyAttempt;
        _networkConnector.OnLobbyJoined += DisplayJoinLobby;
    }

    private void OnDestroy()
    {
        _networkConnector.OnConnectionAttempt -= DisplayConnectionAttempt;
        _networkConnector.OnLobbyJoinAttempt -= DisplayJoinLobbyAttempt;
        _networkConnector.OnLobbyJoined -= DisplayJoinLobby;
    }

    private void DisplayConnectionAttempt(object sender, EventArgs eventArgs) =>
        _text.text = _textEntriesService.GetTextEntry(_connectionAttemptKey);
    
    private void DisplayJoinLobbyAttempt(object sender, EventArgs eventArgs) => 
        _text.text = _textEntriesService.GetTextEntry(_joinLobbyAttemptKey);
    
    private void DisplayJoinLobby(object sender, EventArgs eventArgs) 
        => _text.text = _textEntriesService.GetTextEntry(_joinLobbyKey);
}

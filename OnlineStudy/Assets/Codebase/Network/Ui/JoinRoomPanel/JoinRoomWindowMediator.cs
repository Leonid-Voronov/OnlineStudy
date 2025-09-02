using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class JoinRoomWindowMediator : MonoBehaviour
{
    [SerializeField] private Button _connectButton;
    [SerializeField] private Button _returnButton;
    
    private IRoomConnector _roomConnector;
    private INetworkConnector _networkConnector;
    private IUiRegistry _uiRegistry;

    [Inject]
    public void Construct(IRoomConnector roomConnector, IUiRegistry uiRegistry, INetworkConnector networkConnector)
    {
        _roomConnector = roomConnector;
        _uiRegistry = uiRegistry;
        _networkConnector = networkConnector;
    }

    private void Start()
    {
        _connectButton.onClick.AddListener(ConnectToRoom);
        _returnButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void OnDestroy()
    {
        _connectButton.onClick.RemoveListener(ConnectToRoom);
        _returnButton.onClick.RemoveListener(ReturnToMainMenu);
    }

    private void ConnectToRoom() => _roomConnector.AttemptRoomConnection();

    private void ReturnToMainMenu() => _networkConnector.DisconnectFromNetwork();
}

using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AccountPanelMediator : MonoBehaviour
{
    [SerializeField] private AccountDataDisplay _accountDataDisplay;
    [SerializeField] private Button _closeButton;
    [SerializeField] private NicknameInput _nicknameInput;
    [SerializeField] private Button _nicknameSubmitButton;
    
    private IAccountService _accountService;

    [Inject]
    private void Construct(IAccountService accountService)
    {
        _accountService = accountService;
    }

    private void Start()
    {
        _accountService.NicknameChanged += DisplayAccountData;
        _closeButton.onClick.AddListener(ClosePanel);
        _nicknameSubmitButton.onClick.AddListener(SubmitNickname);
        
        DisplayAccountData(_accountService.Nickname);
    }

    private void OnDestroy()
    {
        _accountService.NicknameChanged -= DisplayAccountData;
        _closeButton.onClick.RemoveListener(ClosePanel);
        _nicknameSubmitButton.onClick.RemoveListener(SubmitNickname);
    }
    
    private void DisplayAccountData(object sender, string nickname) => DisplayAccountData(nickname);
    
    private void DisplayAccountData(string nickname) => _accountDataDisplay.DisplayAccountData(nickname);
    
    private void ClosePanel() => gameObject.SetActive(false);

    private void SubmitNickname()
    {
        _accountService.ChangeNickname(_nicknameInput.GetCurrentInput());
        _nicknameInput.ClearInput();
    }
}

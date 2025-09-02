using UnityEngine;
using UnityEngine.UI;

public class PopUpMediator : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    
    private void Start() => _closeButton.onClick.AddListener(ClosePopUp);

    private void OnDestroy() => _closeButton.onClick.RemoveListener(ClosePopUp);
    
    private void ClosePopUp() => gameObject.SetActive(false);
}

using TMPro;
using UnityEngine;

public class NicknameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    
    public string GetCurrentInput() => _inputField.text;
    
    public void ClearInput() => _inputField.text = "";
}

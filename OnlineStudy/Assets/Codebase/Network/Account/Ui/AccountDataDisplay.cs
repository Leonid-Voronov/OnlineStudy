using TMPro;
using UnityEngine;

public class AccountDataDisplay : MonoBehaviour
{
    private const string EmptyNicknameMessage = "You need to enter a nickname in a field below.";
    
    [SerializeField] private TMP_Text _text;
    
    public void DisplayAccountData(string nickname) 
        => _text.text = string.IsNullOrEmpty(nickname) ? EmptyNicknameMessage : $"Account nickname: {nickname}";
}

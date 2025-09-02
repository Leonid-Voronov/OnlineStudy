using TMPro;
using UnityEngine;

public class PlayerDataDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _nickname;
    
    public void DisplayNickname(string nickname) => _nickname.text = nickname;
}

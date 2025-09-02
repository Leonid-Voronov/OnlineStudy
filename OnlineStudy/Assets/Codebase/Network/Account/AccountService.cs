using System;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class AccountService : IInitializable, IDisposable, IAccountService
{
    public event EventHandler<string> NicknameChanged; 
    
    private const string NicknameKey = "Nickname";

    public bool IsNicknameSet => !String.IsNullOrEmpty(Nickname);
    public string Nickname { get; private set; }
    
    public void Initialize()
    {
        Nickname = PlayerPrefs.GetString(NicknameKey, "");
        if (!string.IsNullOrEmpty(Nickname))
        {
            PhotonNetwork.NickName = Nickname;
        }
    }

    public void Dispose()
    {
        PlayerPrefs.SetString(NicknameKey, Nickname);
    }

    public void ChangeNickname(string newNickname)
    {
        Nickname = newNickname;
        PhotonNetwork.NickName = newNickname;
        NicknameChanged?.Invoke(this, newNickname);
    }
}
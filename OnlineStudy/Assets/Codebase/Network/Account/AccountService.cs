using System;
using UnityEngine;
using Zenject;

public class AccountService : IInitializable, IDisposable, IAccountService
{
    private const string NicknameKey = "Nickname";

    public bool IsNicknameSet => !String.IsNullOrEmpty(Nickname);
    public string Nickname { get; private set; }
    
    public void Initialize()
    {
        Nickname = PlayerPrefs.GetString(NicknameKey, "");
    }

    public void Dispose()
    {
        PlayerPrefs.SetString(NicknameKey, Nickname);
    }

    public void ChangeNickname(string newNickname)
    {
        Nickname = newNickname;
    }
}
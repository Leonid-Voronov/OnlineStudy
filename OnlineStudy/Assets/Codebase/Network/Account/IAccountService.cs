using System;

public interface IAccountService
{
    public event EventHandler<string> NicknameChanged; 
    
    public bool IsNicknameSet { get; }
    public string Nickname { get; }

    public void ChangeNickname(string newNickname);
}
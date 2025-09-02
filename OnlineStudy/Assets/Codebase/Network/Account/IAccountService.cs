public interface IAccountService
{
    public bool IsNicknameSet { get; }
    public string Nickname { get; }

    public void ChangeNickname(string newNickname);
}
using UnityEngine;

public interface IUiRegistry
{
    public void RegisterUI(string key, GameObject ui);
    public void ShowNetworkUi();
    
    public void ShowMainMenuUi();
}
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UiRegistry : IInitializable, IDisposable, IUiRegistry
{
    private Dictionary<string, GameObject> _uis = new ();

    public void Initialize() => _uis = new ();

    public void Dispose()
    {
        _uis.Clear();
        _uis = null;
    }
    
    public void RegisterUI(string key, GameObject ui) => _uis[key] = ui;
    
    public void ShowMainMenuUi() => ShowUi("MainMenu");
    
    public void ShowNetworkUi() => ShowUi("NetworkUi");
    
    private void ShowUi(string key)
    {
        foreach (var ui in _uis.Values)
        {
            ui.gameObject.SetActive(false);
        }
        
        _uis[key].SetActive(true);
    }
}
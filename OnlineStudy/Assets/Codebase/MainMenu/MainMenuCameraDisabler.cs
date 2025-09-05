using System;
using UnityEngine;
using Zenject;

public class MainMenuCameraDisabler : IInitializable, IDisposable
{
    private readonly MainMenuCameraTag _cameraTag;
    private readonly ISceneLoadService _sceneLoadService;

    [Inject]
    public MainMenuCameraDisabler(MainMenuCameraTag cameraTag, ISceneLoadService sceneLoadService)
    {
        _cameraTag = cameraTag;
        _sceneLoadService = sceneLoadService;
    }
    
    public void Initialize()
    {
        _sceneLoadService.AdditiveSceneLoading += DisableMainMenuCamera;
    }

    public void Dispose()
    {
        _sceneLoadService.AdditiveSceneLoading -= DisableMainMenuCamera;
    }
    
    private void DisableMainMenuCamera(object sender, EventArgs eventArgs) => _cameraTag.gameObject.SetActive(false);
}

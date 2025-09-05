using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoadService : ISceneLoadService
{
    public event EventHandler AdditiveSceneLoading;
    
    private const string TestEnvironmentSceneName = "TestEnvironment";
    
    private readonly ILoadingCurtainService _loadingCurtainService;

    [Inject]
    public SceneLoadService(ILoadingCurtainService loadingCurtainService)
    {
        _loadingCurtainService = loadingCurtainService;
    }

    public void LoadTestEnvironment()
    {
        _loadingCurtainService.ShowLoadingCurtain(true);
        AsyncOperation loadOperation = LoadTestEnvironmentScene();
        AdditiveSceneLoading?.Invoke(this, EventArgs.Empty);
        loadOperation.completed += OnLoadComplete();
    }
    
    [PunRPC]
    private AsyncOperation LoadTestEnvironmentScene() 
        => SceneManager.LoadSceneAsync(TestEnvironmentSceneName, LoadSceneMode.Additive);

    private Action<AsyncOperation> OnLoadComplete()
    {
        _loadingCurtainService.ShowLoadingCurtain(false);
        return null;
    }
}
using UnityEngine;
using Zenject;

public class LoadingCurtainService : ILoadingCurtainService, IInitializable
{
    private LoadingCurtainDisplay _loadingCurtainDisplay;
    private IGlobalGameFactory _globalGameFactory;
    
    [Inject]
    public LoadingCurtainService(IGlobalGameFactory globalGameFactory)
    {
        _globalGameFactory = globalGameFactory;
    }

    public void Initialize()
    {
        _loadingCurtainDisplay = _globalGameFactory.CreateLoadingCurtain();
    }

    public void ShowLoadingCurtain(bool show) => _loadingCurtainDisplay.gameObject.SetActive(show);
}
using System;

public interface ISceneLoadService
{
    public event EventHandler AdditiveSceneLoading;
    
    public void LoadTestEnvironment();
}
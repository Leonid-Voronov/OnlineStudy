using UnityEngine;

public class ApplicationQuitter : IApplicationQuitter
{
    public void QuitApplication()
    {
        Application.Quit();
    }
}
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameplayFactory : IGameplayFactory
{
    private const string CharacterPath = "Character";
    
    private DiContainer _diContainer;

    public GameObject CreatePlayer(string sceneName, Vector3 position)
    {
        GameObject newCharacter = PhotonNetwork.Instantiate(CharacterPath, position, Quaternion.identity);
        SceneManager.MoveGameObjectToScene(newCharacter, SceneManager.GetSceneByName(sceneName));
        return newCharacter;
    }
}

public interface IGameplayFactory
{
    public GameObject CreatePlayer(string sceneName, Vector3 position);
}

using UnityEngine;

public interface IGlobalGameFactory
{
    public LoadingCurtainDisplay CreateLoadingCurtain();

    public GameObject CreateNetworkUi(Transform parent);
    public RoomPlayersInfo CreateRoomPlayersInfo();
    public GameObject CreateMainMenu(Transform parent);
}
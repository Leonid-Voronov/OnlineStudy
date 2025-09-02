using UnityEngine;

[CreateAssetMenu(fileName = "MultiplayerConfig", menuName = "ScriptableObjects/MultiplayerConfig")]
public class MultiplayerConfigSo : ScriptableObject
{
    [field: SerializeField] public int MaxPlayersPerRoom { get; private set; }
}

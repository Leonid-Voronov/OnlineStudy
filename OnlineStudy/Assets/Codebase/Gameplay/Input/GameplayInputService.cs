using UnityEngine;
using Zenject;

public class GameplayInputService : IGameplayInputService
{
    private readonly PlayerInput _playerInput;
    
    public Vector2 LookDirection => _playerInput.Gameplay.Look.ReadValue<Vector2>();
    public Vector2 MoveDirection => _playerInput.Gameplay.Move.ReadValue<Vector2>();

    [Inject]
    public GameplayInputService(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }
}
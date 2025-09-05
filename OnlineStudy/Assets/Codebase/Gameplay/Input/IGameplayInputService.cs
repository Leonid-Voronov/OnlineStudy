using UnityEngine;

public interface IGameplayInputService
{
    public Vector2 LookDirection { get; }
    public Vector2 MoveDirection { get; }
}
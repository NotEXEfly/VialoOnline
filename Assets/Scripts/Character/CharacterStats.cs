using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitBtwSteps;
    public float Speed { get => _speed; }
    public float WaitBtwSteps { get => _waitBtwSteps; }

    public Direction ViewDirection { get; set; } = Direction.DOWN;
}


public enum Direction
{
    RIGHT,
    LEFT,
    UP,
    DOWN,
    NONE
}
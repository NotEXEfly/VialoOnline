using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitBtwSteps;
    public float Speed { get => _speed; }
    public float WaitBtwSteps { get => _waitBtwSteps; }

    public Vector2 Direction { get; set; }
    public ViewDirection ViewDirection { get; set; } = ViewDirection.DOWN;

    
    
}


public enum ViewDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}
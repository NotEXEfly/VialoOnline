using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float _speed;
    public float Speed { get => _speed; }

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
﻿using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float _speed;
    public float Speed { get => _speed; }
    

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
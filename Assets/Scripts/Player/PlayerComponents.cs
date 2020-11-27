using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D _rigitBody;

    [SerializeField]
    private AnyStateAnimator _animator;

    [SerializeField]
    private Collider2D _collider;

    [SerializeField]
    private Transform _gridMovePoint;

    [SerializeField]
    private LayerMask _whatStopMovement;

    public Rigidbody2D RigitBody { get => _rigitBody; }
    public AnyStateAnimator Animator { get => _animator; }
    public Collider2D Collider { get => _collider; }
    public Transform GridMovePoint { get => _gridMovePoint; }
    public LayerMask WhatStopMovement { get => _whatStopMovement; }
}

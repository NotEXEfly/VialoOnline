using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class CharacterComponents
{
    [SerializeField] private Rigidbody2D _rigitBody;
    [SerializeField] private AnyStateAnimator _animator;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Transform _nextCellPoint;
    [SerializeField] private List<Tilemap> _obstacleTilemaps;

    public Rigidbody2D RigitBody { get => _rigitBody; }
    public AnyStateAnimator Animator { get => _animator; }
    public Collider2D Collider { get => _collider; }
    public Transform NextCellPoint { get => _nextCellPoint; }
    public List<Tilemap> ObstacleTilemaps { get => _obstacleTilemaps; }
}

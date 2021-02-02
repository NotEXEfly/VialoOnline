using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats _stats;
    [SerializeField] protected CharacterComponents _components;

    public CharacterComponents Components { get => _components; }
    public CharacterStats Stats { get => _stats; }

}

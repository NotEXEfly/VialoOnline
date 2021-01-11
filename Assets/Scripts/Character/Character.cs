using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats _stats;
    [SerializeField] protected CharacterComponents _components;


    protected CharacterActions _actions;

    public CharacterComponents Components { get => _components; }
    public CharacterStats Stats { get => _stats; }
    public CharacterActions Actions { get => _actions; }

    private void Start()
    {
        _components.RealPosition.parent = null;
    }

    protected virtual void FixedUpdate()
    {
        _actions.Move();
    }
}

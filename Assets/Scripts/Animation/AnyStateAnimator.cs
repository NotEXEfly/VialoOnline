using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    private Animator _animator;

    private Dictionary<string, AnyStateAnimation> _animations = new Dictionary<string, AnyStateAnimation>();

    private string _currentAnimationBody = string.Empty;

    public string CurrentAnimationBody { get => _currentAnimationBody; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animate();
    }

    public void AddAnimations(params AnyStateAnimation[] newAnimations)
    {
        for (int i = 0; i < newAnimations.Length; i++)
        {
            _animations.Add(newAnimations[i].Name, newAnimations[i]);
        }
    }

    public void TryPlayAnimation(string newAnimation)
    {
        //if(!_animations.ContainsKey(newAnimation)) return;

        switch (_animations[newAnimation].AnimationRig)
        {
            case RIG.BODY:
                PlayAnimation(ref _currentAnimationBody);
                break;
        }

        void PlayAnimation(ref string currentAnimation)
        {
            if (currentAnimation == "")
            {
                _animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
            if (currentAnimation != newAnimation && !_animations[newAnimation].HigherPrio.Contains(currentAnimation) || !_animations[currentAnimation].Active)
            {
                _animations[currentAnimation].Active = false;
                _animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
        }
    }

    private void Animate()
    { 
        foreach(string key in _animations.Keys)
        {
            _animator.SetBool(key, _animations[key].Active);
        }
    }

    public void OnAnimationDone(string animation)
    {
        _animations[animation].Active = false;
    }
}

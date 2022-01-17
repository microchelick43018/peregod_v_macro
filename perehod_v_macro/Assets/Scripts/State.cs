using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Animator Animator;
    protected Enemy Enemy;

    public Transform Target { get; private set; }

    protected virtual void Awake()
    {
        Enemy = GetComponent<Enemy>();
        Animator = GetComponent<Animator>();
    }

    public virtual void Enter(Transform target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedToTransit == true)
            {
                return transition.TargetState;
            }
        }
        return null;
    }

    public virtual void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }
}

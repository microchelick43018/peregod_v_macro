using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Transform Target;
    protected Enemy Enemy;

    public bool NeedToTransit { get; protected set; }
    public State TargetState => _targetState;

    protected virtual void Awake()
    {
        Enemy = GetComponent<Enemy>();
    }

    protected virtual void OnEnable()
    {
        NeedToTransit = false;
    }

    public virtual void Init(Transform target)
    {
        Target = target;
    }
}

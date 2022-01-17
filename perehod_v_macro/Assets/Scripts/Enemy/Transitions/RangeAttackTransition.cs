using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeAttackState))]

public class RangeAttackTransition : Transition
{
    private RangeAttackState _rangeAttackState;

    protected override void Awake()
    {
        base.Awake();
        _rangeAttackState = GetComponent<RangeAttackState>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void Update()
    {
        NeedToTransit = _rangeAttackState.HasAttacked == true;
    }
}

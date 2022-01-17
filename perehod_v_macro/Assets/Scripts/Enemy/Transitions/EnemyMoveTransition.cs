using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMoveTransition : Transition
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Enemy.MovingSpot) < 0.1f)
        {
            NeedToTransit = true;
        }
    }
}

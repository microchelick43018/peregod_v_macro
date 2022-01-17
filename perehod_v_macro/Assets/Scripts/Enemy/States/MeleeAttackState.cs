using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class MeleeAttackState : State
{

    private void Update()
    {
        transform.LookAt(Target.transform);
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForEndOfFrame();
    }
}

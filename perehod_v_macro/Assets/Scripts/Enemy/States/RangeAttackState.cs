using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : State
{
    [SerializeField] private Bullet _bullet;

    public bool AbleToAttack { get; private set; }
    public bool HasAttacked { get; private set; }

    public override void Enter(Transform target)
    {
        base.Enter(target);
        AbleToAttack = true;
        HasAttacked = false;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Update()
    {
        transform.LookAt(Target.transform);
        if (AbleToAttack == true)
        {
            AbleToAttack = false;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(Enemy.AttackDelay);
        Bullet bullet = Instantiate(_bullet);
        bullet.transform.position = transform.position;
        bullet.SetTarget(Target.transform);
        HasAttacked = true;
    }
}

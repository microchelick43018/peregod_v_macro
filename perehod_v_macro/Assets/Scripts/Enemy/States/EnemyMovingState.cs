using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMovingState : State
{
    public override void Enter(Transform target)
    {
        base.Enter(target);
        Vector3 movingSpot = new Vector3();
        if (Enemy.MovingSpot == Vector3.zero)
        {
            do
            {
                movingSpot = GetNewMovingSpot();
            } while (movingSpot == Vector3.zero);   
            Enemy.AssignMovingSpot(movingSpot);
        }
        transform.LookAt(movingSpot);
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.AssignMovingSpot(Vector3.zero);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (Enemy.MovingSpot != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, Enemy.MovingSpot, Enemy.Speed * Time.deltaTime);
        }
    }

    private Vector3 GetNewMovingSpot()
    {
        //(x-a)^2 + (y-b)^2 = R^2 => y = b +- sqrt(R^2 - (x-a)^2)
        //R = Enemy.MovingRange, a = postion.x, b = postion.z;
        float posX = Random.Range(transform.position.x - Enemy.MovingRange, transform.position.x + Enemy.MovingRange);
        
        float posZ = transform.position.z + Mathf.Sign(Random.Range(-1, 1))
            * Mathf.Sqrt(Enemy.MovingRange * Enemy.MovingRange - (posX - transform.position.x) * (posX - transform.position.x));
        Vector3 movingSpot = new Vector3(posX, transform.position.y, posZ);
        Ray ray = new Ray(transform.position, (movingSpot - transform.position).normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, Enemy.MovingRange))
        {
            if (hit.collider.TryGetComponent(out Player player) == false)
                return Vector3.zero;
        }
        return movingSpot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _attackCooldown;

    private List<Enemy> _enemies;
    private Enemy _currentTarget;
    private int _coinsCount;
    private bool _ableToAttack;
    private Transform _lastTransform;

    public int Speed => _speed;
    public int CoinsCount => _coinsCount;

    private void Awake()
    {
       _enemies = FindObjectsOfType<Enemy>().ToList();
       _enemies = _enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position)).ToList();
        _ableToAttack = true;
    }

    private void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01f)
        {
            _currentTarget = FindTarget();
            if (_currentTarget != null)
            {
                if (_ableToAttack == true)
                {
                    _ableToAttack = false;
                    StartCoroutine(Attack());
                }             
            }
        }
    }

    private Enemy FindTarget()
    {
        List<Enemy> targetsThroughSpace = new List<Enemy>();
        List<Enemy> targetsThroughWall = new List<Enemy>();
        Enemy target = null;
        foreach (var enemy in _enemies)
        {
            if (enemy == null)
            {
                _enemies.Remove(enemy);
            }
            Ray ray = new Ray(transform.position, (enemy.transform.position - transform.position));
            if (Physics.Raycast(ray, out RaycastHit hit, Vector3.Distance(transform.position, enemy.transform.position)))
            {
                if (hit.collider.TryGetComponent(out Wall wall))
                {
                    targetsThroughWall.Add(enemy);
                }
                else
                {
                    targetsThroughSpace.Add(enemy);
                }
            }
        }
        if (targetsThroughSpace.Count != 0)
        {
            target = targetsThroughSpace[0];
        }
        else if (targetsThroughWall.Count != 0)
        {
            target = targetsThroughWall[0];
        }
        return target;
    }

    private IEnumerator Attack()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.SetTarget(_currentTarget.transform);
        bullet.transform.position = transform.position;
        bullet.transform.LookAt(_currentTarget.transform);
        yield return new WaitForSeconds(_attackCooldown);
        _ableToAttack = true;
    }
}

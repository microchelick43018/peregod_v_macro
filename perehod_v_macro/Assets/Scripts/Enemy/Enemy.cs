using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _movingRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackDamage;

    private Vector3 _movingSpot;

    public Vector3 MovingSpot => _movingSpot;
    public float MovingRange => _movingRange;
    public float Speed => _speed;
    public float AttackDelay => _attackDelay;
    public float AttackDamage => _attackDamage;
    public int Health => _health;

    private void Awake()
    {

    }

    public void AssignMovingSpot(Vector3 movingSpot)
    {
        _movingSpot = movingSpot;
    }
}

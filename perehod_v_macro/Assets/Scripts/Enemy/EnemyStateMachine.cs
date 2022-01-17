using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    [SerializeField] private Transform _target;

    private State _currentState;
    private Enemy _enemy;

    public State CurrentState => _currentState;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        Reset(_firstState);
    }

    private void Update()
    {
        var nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}

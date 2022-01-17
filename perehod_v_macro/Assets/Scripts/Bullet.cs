using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Transform _target;

    public float Speed => _speed;

    public void SetTarget(Transform target)
    {
        _target = target;
        transform.LookAt(target);
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target || other.TryGetComponent(out Wall wall) == true)
        {
            Destroy(this.gameObject);
        }
    }
}

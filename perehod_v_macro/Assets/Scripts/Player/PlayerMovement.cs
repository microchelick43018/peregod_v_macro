using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private Player _player;
    private float _deltaX = 0, _deltaZ;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _deltaX = Input.GetAxis("Horizontal");
        _deltaZ = Input.GetAxis("Vertical");
        Vector3 movementVector = new Vector3(_deltaX, 0, _deltaZ);
        movementVector = Vector3.ClampMagnitude(movementVector, _player.Speed);
        movementVector = transform.TransformDirection(movementVector);
        movementVector *= Time.deltaTime * _player.Speed;
        _characterController.Move(movementVector);
    }
}

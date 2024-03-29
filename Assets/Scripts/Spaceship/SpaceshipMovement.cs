﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private IInput _input;
    private Vector2 _movementVector;
    private Vector2 _startingPosition;
    private Vector2 _currentPos;
    private Vector2 _movementSpeed;
    private float _dir;


    public void SetMovementSpeed(Vector2 movementSpeed) 
    {
        _movementSpeed = movementSpeed;
    }

    private void Awake()
    {
        _input = GetComponent<IInput>();    
    }

    private void Start()
    {
        _startingPosition = transform.position;
        _currentPos = _startingPosition;
    }

    private void Update()
    {
        _movementVector.x = _input.HorizontalInput;
        _movementVector.y = _input.VerticalInput;
        _dir = transform.rotation.z == 0 ? 1 : -1;
    }

    private void FixedUpdate()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        _currentPos += Vector2.one * _movementVector * Time.deltaTime * _movementSpeed * _dir;
        _rigidbody2D.MovePosition(_currentPos);
    }
}

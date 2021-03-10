﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    private float _verticalDirection;
    private float _yPositionBeforeStartingVerticalMovement;
    private float _verticalPositionChangeDuringVerticalMovement;
    private float _numberOfArrivalsOnEdges;
    private float _verticalMovementDistance = 1f;
    private float _minHorizontalPosition;
    private float _maxHorizontalPosition;
    private Vector2 _movementVector;

    public Vector2 MovementVector 
    {
        get
        {
            return _movementVector;
        }
    }


    public void SetMinAndMaxHorizontalPositions(float min, float max)
    {
        _minHorizontalPosition = min;
        _maxHorizontalPosition = max;
    }

    private void OnEnable()
    {
        _movementVector.x = 1f;
    }

    void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateVerticalDirection();
        UpdateVerticalPositionChangeDuringVerticalMovement();
        CheckIfVerticalMovementShouldStopAndResetValuesIfNecessary();

        if (CanMoveHorizontally())
        {
            UpdateHorizontalMovementValuesAndCountArrivalsOnEdges();
        }

        if (ShouldStartVerticalMovement())
        {
            _numberOfArrivalsOnEdges = 0;
            _movementVector = new Vector2(0, 1);
            _yPositionBeforeStartingVerticalMovement = transform.position.y;
        }
    }

    private void UpdateVerticalDirection()
    {
        _verticalDirection = (transform.rotation.eulerAngles.z + 360) % 360 == 180 ? -1f : 1f;
    }

    private void UpdateVerticalPositionChangeDuringVerticalMovement()
    {
        _verticalPositionChangeDuringVerticalMovement = Mathf.Abs(transform.position.y - _yPositionBeforeStartingVerticalMovement);
    }

    private void CheckIfVerticalMovementShouldStopAndResetValuesIfNecessary()
    {
        if (ShouldStopVerticalMovement())
        {
            _movementVector.y = 0f;
            _yPositionBeforeStartingVerticalMovement = float.MaxValue;
        }
    }

    private bool CanMoveHorizontally()
    {
        return _movementVector.y == 0f;
    }

    private void UpdateHorizontalMovementValuesAndCountArrivalsOnEdges()
    {
        if (transform.position.x < _minHorizontalPosition)
        {
            _movementVector.x = -1f;
            _numberOfArrivalsOnEdges++;
        }
        if (transform.position.x > _maxHorizontalPosition)
        {
            _movementVector.x = 1f;
            _numberOfArrivalsOnEdges++;
        }
    }

    private bool ShouldStartVerticalMovement()
    {
        return _numberOfArrivalsOnEdges > 2;
    }

    private bool ShouldStopVerticalMovement()
    {
        return _verticalPositionChangeDuringVerticalMovement > _verticalMovementDistance && _movementVector.y != 0 && _yPositionBeforeStartingVerticalMovement != float.MaxValue;
    }
}

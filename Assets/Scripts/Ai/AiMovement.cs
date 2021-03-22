using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    private const float _horizontalPositionOffset = 2f;
    private float _timeLeftBeforeNextVerticalMovement;
    private float _yPositionBeforeStartingVerticalMovement;
    private float _verticalPositionChangeDuringVerticalMovement;
    private float _verticalMovementDistance = 1f;
    private float _horizontalMovementDirectionBeforeStartingVerticalMovement;
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


    public void SetMinAndMaxHorizontalPositions(float minHorizontal, float maxHorizontal)
    {
        _minHorizontalPosition = minHorizontal + _horizontalPositionOffset;
        _maxHorizontalPosition = maxHorizontal - _horizontalPositionOffset;
    }

    private void OnEnable()
    {
        SetMovementVectorForStart();
        SetTimeBeforeNextVerticalMovement();
    }

    private void SetMovementVectorForStart()
    {
        _movementVector = new Vector2(1f, 0f);
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateVerticalPositionChangeDuringVerticalMovement();
        UpdateTimeCountdownBeforeNextVerticalMovementStartIfNotMovingVertically();
        StopVerticalMovementIfNecessary();

        if (CanMoveHorizontally())
        {
            UpdateMovementVectorForHorizontalMovement();
        }

        if (ShouldStartVerticalMovement())
        {
            StartVerticalMovement();
        }
    }

    private void UpdateVerticalPositionChangeDuringVerticalMovement()
    {
        _verticalPositionChangeDuringVerticalMovement = Mathf.Abs(transform.position.y - _yPositionBeforeStartingVerticalMovement);
    }

    private void UpdateTimeCountdownBeforeNextVerticalMovementStartIfNotMovingVertically()
    {
        if (_movementVector.y == 0)
        {
            _timeLeftBeforeNextVerticalMovement -= Time.deltaTime;
        }
    }

    private void StopVerticalMovementIfNecessary()
    {
        if (ShouldStopVerticalMovement())
        {
            StopVerticalMovement();
        }
    }

    private bool ShouldStopVerticalMovement()
    {
        return HasCompletedVerticalMovement() && MovesVertically() && VerticalPositionWasCachedBeforeStartingVerticalMovement();
    }

    private bool HasCompletedVerticalMovement()
    {
        return _verticalPositionChangeDuringVerticalMovement > _verticalMovementDistance;
    }

    private bool MovesVertically()
    {
        return _movementVector.y != 0;
    }

    private bool VerticalPositionWasCachedBeforeStartingVerticalMovement()
    {
        return _yPositionBeforeStartingVerticalMovement != float.MaxValue;
    }

    private void StopVerticalMovement()
    {
        _movementVector.x = _horizontalMovementDirectionBeforeStartingVerticalMovement;
        _movementVector.y = 0f;
        _yPositionBeforeStartingVerticalMovement = float.MaxValue;
    }

    private bool CanMoveHorizontally()
    {
        return _movementVector.y == 0f;
    }

    private void UpdateMovementVectorForHorizontalMovement()
    {
        if (transform.position.x < _minHorizontalPosition)
        {
            _movementVector.x = -1f;
        }
        if (transform.position.x > _maxHorizontalPosition)
        {
            _movementVector.x = 1f;
        }
    }

    private bool ShouldStartVerticalMovement()
    {
        return _timeLeftBeforeNextVerticalMovement < 0f;
    }

    private void StartVerticalMovement()
    {
        SetTimeBeforeNextVerticalMovement();
        _horizontalMovementDirectionBeforeStartingVerticalMovement = _movementVector.x;
        _movementVector = new Vector2(0, 1);
        _yPositionBeforeStartingVerticalMovement = transform.position.y;
    }

    private void SetTimeBeforeNextVerticalMovement()
    {
        _timeLeftBeforeNextVerticalMovement = AiSpaceshipsRow.TimeBetweenVerticalMovements;
    }
}

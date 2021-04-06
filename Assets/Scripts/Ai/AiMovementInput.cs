using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovementInput : MovementInput
{
    private const float _horizontalPositionOffset = 2f;
    private float _timeLeftBeforeNextVerticalMovement;
    private float _yPositionBeforeStartingVerticalMovement;
    private float _verticalPositionChangeDuringVerticalMovement;
    private float _verticalMovementDistance = 1f;
    private float _horizontalMovementDirectionBeforeStartingVerticalMovement;


    public override void SetMinAndMaxHorizontalPositions(float minHorizontal, float maxHorizontal)
    {
        base.SetMinAndMaxHorizontalPositions(minHorizontal + _horizontalPositionOffset, maxHorizontal - _horizontalPositionOffset);
    }

    protected override void UpdateMovementInput()
    {
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

    private void OnEnable()
    {
        SetMovementVectorForStart();
        SetTimeBeforeNextVerticalMovement();
    }

    private void SetMovementVectorForStart()
    {
        MovementVector = new Vector2(1f, 0f);
    }

    private void UpdateVerticalPositionChangeDuringVerticalMovement()
    {
        _verticalPositionChangeDuringVerticalMovement = Mathf.Abs(transform.position.y - _yPositionBeforeStartingVerticalMovement);
    }

    private void UpdateTimeCountdownBeforeNextVerticalMovementStartIfNotMovingVertically()
    {
        if (MovementVector.y == 0)
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
        return MovementVector.y != 0;
    }

    private bool VerticalPositionWasCachedBeforeStartingVerticalMovement()
    {
        return _yPositionBeforeStartingVerticalMovement != float.MaxValue;
    }

    private void StopVerticalMovement()
    {
        MovementVector = new Vector2(_horizontalMovementDirectionBeforeStartingVerticalMovement, 0f);
        _yPositionBeforeStartingVerticalMovement = float.MaxValue;
    }

    private bool CanMoveHorizontally()
    {
        return MovementVector.y == 0f;
    }

    private void UpdateMovementVectorForHorizontalMovement()
    {
        if (transform.position.x < _minHorizontalPosition)
        {
            MovementVector = new Vector2(-1f,MovementVector.y);
        }
        if (transform.position.x > _maxHorizontalPosition)
        {
            MovementVector = new Vector2(1f, MovementVector.y);
        }
    }

    private bool ShouldStartVerticalMovement()
    {
        return _timeLeftBeforeNextVerticalMovement < 0f;
    }

    private void StartVerticalMovement()
    {
        SetTimeBeforeNextVerticalMovement();
        _horizontalMovementDirectionBeforeStartingVerticalMovement = MovementVector.x;
        MovementVector = new Vector2(0, 1);
        _yPositionBeforeStartingVerticalMovement = transform.position.y;
    }

    private void SetTimeBeforeNextVerticalMovement()
    {
        _timeLeftBeforeNextVerticalMovement = AiSpaceshipsRow.TimeBetweenVerticalMovements;
    }
}

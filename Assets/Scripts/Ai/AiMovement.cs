using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    private const float _minDefaultTimeBetweenVerticalMovements = 5f;
    private const float _maxDefaultTimeBetweenVerticalMovements = 10f;
    private const float _horizontalPositionsOffset = 2f;
    private float _timeLeftBeforeNextVerticalMovement;
    private float _yPositionBeforeStartingVerticalMovement;
    private float _verticalPositionChangeDuringVerticalMovement;
    private float _verticalMovementDistance = 1f;
    private float _horizontalMovementDirectionBeforeStartingVerticalMovement;
    private float _minHorizontalPosition;
    private float _maxHorizontalPosition;
    private float _newMinHorizontalPosition;
    private float _newMaxHorizontalPosition;
    private bool _updateMinAndMaxHorizontalPositionsAfterVerticalMovementEnds;
    private Vector2 _movementVector;

    public Vector2 MovementVector 
    {
        get
        {
            return _movementVector;
        }
    }


    public void SetMinAndMaxHorizontalPositionsOrQueueThemIfAiMovesVertically(float minHorizontal, float maxHorizontal)
    {
        //if (MovesVertically())
        //{
        //    SetNewMinAndMaxHorizontalPositions(minHorizontal, maxHorizontal);
        //    _updateMinAndMaxHorizontalPositionsAfterVerticalMovementEnds = true;
        //    return;
        //}
        SetMinAndMaxHorizontalPositions(minHorizontal, maxHorizontal);
    }

    private void SetNewMinAndMaxHorizontalPositions(float minHorizontal, float maxHorizontal)
    {
        _newMinHorizontalPosition = minHorizontal;
        _newMaxHorizontalPosition = maxHorizontal;
    }

    private void SetMinAndMaxHorizontalPositions(float minHorizontal,float maxHorizontal)
    {
        _minHorizontalPosition = minHorizontal + _horizontalPositionsOffset;
        _maxHorizontalPosition = maxHorizontal - _horizontalPositionsOffset;
    }

    private void OnEnable()
    {
        SetMovementVectorForStart();
        SetRandomTimeBeforeNextVerticalMovement();
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateVerticalPositionChangeDuringVerticalMovement();
        UpdateVerticalMovementTimeCounterIfNotMovingVertically();
        StopVerticalMovementIfNecessary();
        //UpdateMinAndMaxHorizontalPositionsIfVerticalMovementHasEnded();

        if (CanMoveHorizontally())
        {
            UpdateHorizontalMovementValues();
        }

        if (ShouldStartVerticalMovement())
        {
            StartVerticalMovement();
        }
    }

    private void SetMovementVectorForStart()
    {
        _movementVector = new Vector2(1f, 0f);
    }

    private void UpdateVerticalMovementTimeCounterIfNotMovingVertically()
    {
        if (_movementVector.y == 0)
        {
            _timeLeftBeforeNextVerticalMovement -= Time.deltaTime;
        }
    }

    private void UpdateVerticalPositionChangeDuringVerticalMovement()
    {
        _verticalPositionChangeDuringVerticalMovement = Mathf.Abs(transform.position.y - _yPositionBeforeStartingVerticalMovement);
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

    private void UpdateMinAndMaxHorizontalPositionsIfVerticalMovementHasEnded()
    {
        if (ShouldUpdateMinAndMaxHorizontalPositions())
        {
            _updateMinAndMaxHorizontalPositionsAfterVerticalMovementEnds = false;
            SetMinAndMaxHorizontalPositions(_newMinHorizontalPosition, _newMaxHorizontalPosition);
            _newMinHorizontalPosition = 0f;
            _newMaxHorizontalPosition = 0f;
        }
    }

    private bool ShouldUpdateMinAndMaxHorizontalPositions()
    {
        return !MovesVertically() && _updateMinAndMaxHorizontalPositionsAfterVerticalMovementEnds;
    }

    private bool CanMoveHorizontally()
    {
        return _movementVector.y == 0f;
    }

    private void UpdateHorizontalMovementValues()
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
        SetRandomTimeBeforeNextVerticalMovement();
        _horizontalMovementDirectionBeforeStartingVerticalMovement = _movementVector.x;
        _movementVector = new Vector2(0, 1);
        _yPositionBeforeStartingVerticalMovement = transform.position.y;
    }

    private void SetRandomTimeBeforeNextVerticalMovement()
    {
        _timeLeftBeforeNextVerticalMovement = AiSpaceshipsRow.TimeBetweenVerticalMovements;
    }
}

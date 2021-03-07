using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiInput : MonoBehaviour, IInput
{
    private const float _minShootingCooldownTimeInSeconds = 1f;
    private const float _maxShootingCooldownTimeInSeconds = 12f;
    private const float _maxDistanceFromStartingPosition = 3f;

    private float _verticalDirection;
    private float _shootingCooldownTimerInSeconds;
    private float _currentCooldownTimeInSeconds;
    private float _verticalMovementDistance = 1f;
    private float _minHorizontalPosition;
    private float _maxHorizontalPosition;
    private float _numberOfArrivalsOnEdges;
    private float _horizontalInput;
    private float _yPositionBeforeStartingVerticalMovement;
    private float _verticalPositionChangeDuringVerticalMovement;

    public float HorizontalInput
    { 
        get
        {
            if (VerticalInput == 0f)
            {
                return _horizontalInput;
            }
            return 0f;
        }
        private set
        {
            _horizontalInput = value;
        }
    }
    public float VerticalInput { get; private set; }
    public bool Firing { get; private set; }


    public void SetMinAndMaxHorizontalPositions(float min, float max)
    {
        _minHorizontalPosition = min;
        _maxHorizontalPosition = max;
    }

    private void OnEnable()
    {
        HorizontalInput = 1f;
        SetCooldownTimeRandomly();
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        _shootingCooldownTimerInSeconds += Time.deltaTime;
        Firing = false;
        UpdateVerticalDirection();
        UpdateVerticalPositionChangeDuringVerticalMovement();
        CheckIfVerticalMovementShouldStopAndResetValuesIfNecessary();
        CheckIfShootingCooldownTimeHasEndedAndResetItIfNecessary();

        if (CanUpdateHorizontalInput())
        {
            UpdateHorizontalInput();
        }

        if (ShouldStartVerticalMovement())
        {
            _numberOfArrivalsOnEdges = 0;
            VerticalInput = 1f;
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
            VerticalInput = 0f;
            _yPositionBeforeStartingVerticalMovement = float.MaxValue;
        }
    }

    private void CheckIfShootingCooldownTimeHasEndedAndResetItIfNecessary()
    {
        if (_shootingCooldownTimerInSeconds > _currentCooldownTimeInSeconds)
        {
            _shootingCooldownTimerInSeconds = 0f;
            if (CanShoot())
            {
                SetCooldownTimeRandomly();
                //Firing = true;
            }
        }
    }

    private bool ShouldStopVerticalMovement()
    {
        return _verticalPositionChangeDuringVerticalMovement > _verticalMovementDistance && VerticalInput != 0 && _yPositionBeforeStartingVerticalMovement != float.MaxValue;
    }

    private bool CanShoot()
    {
        Vector2 rayDirection = Vector2.up * _verticalDirection;
        float rayDistance = 5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayDistance);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, rayDirection, Color.white);
#endif

        if (hit.transform != null && hit.transform.CompareTag("Enemy"))
        {
            return false;
        }
        return true;
    }

    private bool CanUpdateHorizontalInput()
    {
        return VerticalInput == 0f;
    }

    private void UpdateHorizontalInput()
    {
        if (transform.position.x < _minHorizontalPosition)
        {
            HorizontalInput = -1f;
            _numberOfArrivalsOnEdges++;
        }
        if (transform.position.x > _maxHorizontalPosition)
        {
            HorizontalInput = 1f;
            _numberOfArrivalsOnEdges++;
        }
    }

    private bool ShouldStartVerticalMovement()
    {
        return _numberOfArrivalsOnEdges > 2;
    }

    private void SetCooldownTimeRandomly()
    {
        _currentCooldownTimeInSeconds = Random.Range(_minShootingCooldownTimeInSeconds, _maxShootingCooldownTimeInSeconds);
    }
}

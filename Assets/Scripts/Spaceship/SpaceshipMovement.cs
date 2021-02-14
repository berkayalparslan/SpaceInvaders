using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    private IInput _input;
    private Vector2 _movementVector;
    private Vector2 _startingPosition;
    private Vector2 _currentPos;
    private float _maxDistanceChange;
    [SerializeField]
    private float _movementSpeed;


    private void Awake()
    {
        _input = GetComponent<IInput>();    
    }

    private void OnEnable()
    {
        _startingPosition = transform.position;
        _currentPos = _startingPosition;
        SetMaxDistanceFromStartingPosition();
    }

    private void Update()
    {
        _movementVector.x = _input.HorizontalInput;
        _currentPos += Vector2.right * _movementVector.x * Time.deltaTime * _movementSpeed;
        _currentPos.x = Mathf.Clamp(_currentPos.x, _startingPosition.x - _maxDistanceChange, _startingPosition.x + _maxDistanceChange);
        transform.position = _currentPos;
    }

    private void SetMaxDistanceFromStartingPosition()
    {
        if (_input as AiInput != null)
        {
            _maxDistanceChange = 3f;
        }
        else if (_input as PlayerInput != null)
        {
            _maxDistanceChange = 32.5f;
        }
    }
}

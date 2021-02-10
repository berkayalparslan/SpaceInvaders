using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Vector2 _movementVector;
    [SerializeField]
    private float _movementSpeed;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();    
    }


    private void Update()
    {
        _movementVector.x = _playerInput.HorizontalInput;
        transform.Translate(_movementVector * Time.deltaTime * _movementSpeed);
        
    }
}

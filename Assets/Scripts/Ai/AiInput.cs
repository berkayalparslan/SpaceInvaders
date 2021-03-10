using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiInput : MonoBehaviour, IInput
{
    private AiShooting _aiShooting;
    private AiMovement _aiMovement;
    private Vector2 _movementInput;

    public float HorizontalInput
    { 
        get
        {
            return _movementInput.x;
        }
    }
    public float VerticalInput 
    { 
        get
        {
            return _movementInput.y;
        }        
    }
    public bool Firing { get; private set; }


    private void Awake()
    {
        _aiShooting = GetComponent<AiShooting>();
        _aiMovement = GetComponent<AiMovement>();
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateFiringInput();
        UpdateMovementInput();
    }

    private void UpdateFiringInput()
    {
        Firing = _aiShooting.Fire;
    }

    private void UpdateMovementInput()
    {
        _movementInput = _aiMovement.MovementVector;
    }
}

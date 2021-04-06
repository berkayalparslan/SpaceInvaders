using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase : MonoBehaviour, IInput
{
    protected ShootingInput _shootingInput;
    protected MovementInput _movementInput;

    public float HorizontalInput { get; protected set; }
    public float VerticalInput { get; protected set; }
    public bool Firing { get; protected set; }

    protected abstract void UpdateFiringInput();
    protected abstract void UpdateMovementInput();

    private void Awake()
    {
        _shootingInput = GetComponent<ShootingInput>();
        _movementInput = GetComponent<MovementInput>();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiInput : InputBase
{
    protected override void UpdateFiringInput()
    {
        Firing = _shootingInput.Firing;
    }

    protected override void UpdateMovementInput()
    {
        HorizontalInput = _movementInput.MovementVector.x;
        VerticalInput = _movementInput.MovementVector.y;
    }
}

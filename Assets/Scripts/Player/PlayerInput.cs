using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputBase
{
    protected override void UpdateFiringInput()
    {
        Firing = _shootingInput.Firing;
    }

    protected override void UpdateMovementInput()
    {
        HorizontalInput = _movementInput.MovementVector.x;
    }
}

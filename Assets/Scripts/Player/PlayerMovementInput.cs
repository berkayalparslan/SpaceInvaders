using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInput : MovementInput
{
    private float _horizontalInput;

    protected override void UpdateMovementInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (ReachedMinHorizontalPositionAndTryingToGoFurther() || ReachedMaxHorizontalPositionAndTryingToGoFurther())
        {
            MovementVector = new Vector2(0f, MovementVector.y);
        }
        else
        {
            MovementVector = new Vector2(_horizontalInput, MovementVector.y);
        }
    }

    private bool ReachedMinHorizontalPositionAndTryingToGoFurther()
    {
        return transform.position.x < _minHorizontalPosition && _horizontalInput == -1f;
    }

    private bool ReachedMaxHorizontalPositionAndTryingToGoFurther()
    {
        return transform.position.x > _maxHorizontalPosition && _horizontalInput == 1f;
    }
}

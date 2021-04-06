using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementInput : MonoBehaviour
{
    protected float _minHorizontalPosition;
    protected float _maxHorizontalPosition;

    public Vector2 MovementVector { get; protected set; }
 
    protected abstract void UpdateMovementInput();


    public virtual void SetMinAndMaxHorizontalPositions(float minHorizontal, float maxHorizontal)
    {
        _minHorizontalPosition = minHorizontal;
        _maxHorizontalPosition = maxHorizontal;
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateMovementInput();
    }
}

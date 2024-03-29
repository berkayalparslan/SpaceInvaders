﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    private SpaceshipSprite _spaceshipSprite;
    [SerializeField]
    private SpaceshipMovement _spaceshipMovement;
    [SerializeField]
    private MovementInput _movementInput;
    [SerializeField]
    protected SpaceshipHealth _spaceshipHealth;

    public abstract void ProcessSpaceshipHit();

    public void SetMovementSpeed(Vector2 movementSpeed)
    {
        _spaceshipMovement.SetMovementSpeed(movementSpeed);
    }

    public void SetHorizontalMovementBorders(Vector3 origin, float movementRange)
    {
        _movementInput.SetMinAndMaxHorizontalPositions(origin.x - movementRange, origin.x + movementRange);
    }

    public void SetNumberOfLives(short numberOfLives)
    {
        _spaceshipHealth.SetNumberOfLives(numberOfLives);
    }

    protected void SetSpaceshipSprite(SpaceshipType type, SpaceshipColor color)
    {
        Sprite sprite = Managers.Instance.ResourcesManager.GetSpriteBySpaceshipTypeAndColor(type, color);

        if (sprite != null)
        {
            _spaceshipSprite.SetSprite(sprite);
        }
    }
}

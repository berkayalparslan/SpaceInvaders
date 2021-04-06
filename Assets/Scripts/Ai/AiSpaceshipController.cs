using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiSpaceshipController : SpaceshipController
{
    public event UnityAction<AiSpaceshipController> OnSpaceshipDestroy;

    public void InitSpaceshipBeforeActivating(AiSpaceshipsRow aiSpaceshipsRow, Vector3 origin, Quaternion rotation,float movementRange, Vector2 movementSpeed)
    {
        SetSpaceshipSprite(aiSpaceshipsRow.SpaceshipTypeOnThisRow,aiSpaceshipsRow.SpaceshipColorOnThisRow);
        SetHorizontalMovementBorders(origin, movementRange);
        SetMovementSpeed(movementSpeed);
        AssignPositionAndRotation(origin, rotation);
        EnableObject();
    }

    public void DestroySpaceship()
    {
        if (OnSpaceshipDestroy != null)
        {
            OnSpaceshipDestroy(this);
        }
        OnSpaceshipDestroy = null;
        Destroy(gameObject);
    }

    private void AssignPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    private void EnableObject()
    {
        gameObject.SetActive(true);
    }
}

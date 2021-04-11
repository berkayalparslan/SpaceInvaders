using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiSpaceshipController : SpaceshipController
{
    public event UnityAction<AiSpaceshipController> OnSpaceshipDestroy;

    public void InitSpaceshipAndActivateIt(AiSpaceshipsRowController aiSpaceshipsRow, Vector3 origin, Quaternion rotation,float movementRange, Vector2 movementSpeed, short numberOfLives)
    {
        SetSpaceshipSprite(aiSpaceshipsRow.SpaceshipTypeOnThisRow,aiSpaceshipsRow.SpaceshipColorOnThisRow);
        SetHorizontalMovementBorders(origin, movementRange);
        SetMovementSpeed(movementSpeed);
        SetNumberOfLives(numberOfLives);
        AssignPositionAndRotation(origin, rotation);
        gameObject.SetActive(true);
    }

    public override void ProcessSpaceshipHit()
    {
        if(!_spaceshipHealth.IsAlive)
        {
            Managers.Instance.PlayerScoreManager.AddScoreForKill();
            DestroySpaceship();
        }
    }

    private void AssignPositionAndRotation(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    private void DestroySpaceship()
    {
        if (OnSpaceshipDestroy != null)
        {
            OnSpaceshipDestroy(this);
        }
        OnSpaceshipDestroy = null;
        Destroy(gameObject);
    }
}

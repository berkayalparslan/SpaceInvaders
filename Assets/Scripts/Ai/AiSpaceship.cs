using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AiSpaceship : MonoBehaviour
{
    public event UnityAction<AiSpaceship> OnSpaceshipDisable;
    [SerializeField]
    private SpaceshipAppearance _spaceshipAppearance;
    [SerializeField]
    private AiMovement _aiMovement;
    [SerializeField]
    private SpaceshipMovement _spaceshipMovement;


    public void InitSpaceshipBeforeActivating(AiSpaceshipsRow aiSpaceshipsRow, Vector3 origin, Quaternion rotation,float movementRange, Vector2 movementSpeed)
    {
        SetSpaceshipSprite(aiSpaceshipsRow);
        SetHorizontalMovementBorders(origin, movementRange);
        SetMovementSpeed(movementSpeed);
        AssignPositionAndRotation(origin, rotation);
        EnableObject();
    }

    public void SetHorizontalMovementBorders(Vector3 origin, float movementRange)
    {
        _aiMovement.SetMinAndMaxHorizontalPositions(origin.x - movementRange, origin.x + movementRange);
    }

    public void SetMovementSpeed(Vector2 movementSpeed)
    {
        _spaceshipMovement.SetMovementSpeed(movementSpeed);
    }

    private void OnDisable()
    {
        if (OnSpaceshipDisable != null)
        {
            OnSpaceshipDisable(this);
        }
    }

    private void OnDestroy()
    {
        OnSpaceshipDisable = null;
    }

    private void SetSpaceshipSprite(AiSpaceshipsRow aiSpaceshipsRow)
    {
        ResourcesManager resourcesManager = Managers.Instance.ResourcesManager;
        Sprite spaceshipSprite = resourcesManager.GetSpriteBySpaceshipTypeAndColor(aiSpaceshipsRow.SpaceshipTypeOnThisRow, aiSpaceshipsRow.SpaceshipColorOnThisRow);
        _spaceshipAppearance.SetSprite(spaceshipSprite);
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

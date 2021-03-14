using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceship : MonoBehaviour
{
    private const float _defaultHorizontalDistance = 3f;
    [SerializeField]
    private SpaceshipAppearance _spaceshipAppearance;
    [SerializeField]
    private AiMovement _aiMovement;
    private AiSpaceshipsRow _row;


    public void InitSpaceshipBeforeActivating(AiSpaceshipsRow aiSpaceshipsRow, Transform aiSpaceshipSlot)
    {
        _row = aiSpaceshipsRow;

        SetSpaceshipSprite();
        SetHorizontalMovementBorders(aiSpaceshipSlot.position.x - _defaultHorizontalDistance, aiSpaceshipSlot.position.x + _defaultHorizontalDistance);
        AssignPositionAndRotationFromTransform(aiSpaceshipSlot);
        EnableObject();
    }

    private void SetSpaceshipSprite()
    {
        ResourcesManager resourcesManager = Managers.Instance.ResourcesManager;
        Sprite spaceshipSprite = resourcesManager.GetSpriteBySpaceshipTypeAndColor(_row.SpaceshipTypeOnThisRow, _row.SpaceshipColorOnThisRow);
        _spaceshipAppearance.SetSprite(spaceshipSprite);
    }

    private void SetHorizontalMovementBorders(float min, float max)
    {
        _aiMovement.SetMinAndMaxHorizontalPositions(min, max);
    }

    private void AssignPositionAndRotationFromTransform(Transform transform)
    {
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;
    }

    private void EnableObject()
    {
        gameObject.SetActive(true);
    }
}

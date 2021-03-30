using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    private SpaceshipSprite _spaceshipSprite;
    [SerializeField]
    private SpaceshipMovement _spaceshipMovement;


    public void SetMovementSpeed(Vector2 movementSpeed)
    {
        _spaceshipMovement.SetMovementSpeed(movementSpeed);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipController : SpaceshipController
{
    public void InitSpaceshipBeforeActivating(SpaceshipType type, SpaceshipColor color)
    {
        SetSpaceshipSprite(type, color);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipController : SpaceshipController
{
    public void InitSpaceshipBeforeActivating(SpaceshipType type, SpaceshipColor color)
    {
        SetSpaceshipSprite(type, color);
    }

    public override void ProcessSpaceshipHit()
    {
        if (!_spaceshipHealth.IsAlive)
        {
            //gameover
            return;
        }
        gameObject.SetActive(false);
        Managers.Instance.PlayerManager.PauseAndContinueGameAfterPlayerRespawn();
    }
}

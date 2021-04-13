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
        gameObject.SetActive(false);
        Managers.Instance.UiManager.UiPlayerHud.DecreasePlayerLife();
        Managers.Instance.PlayerScoreManager.SubScoreForReceivingHit();
        Managers.Instance.PlayerManager.PlayExplosionSound();

        if (!_spaceshipHealth.IsAlive)
        {
            Managers.Instance.PlayerManager.EndGame(false);
            return;
        }
        Managers.Instance.PlayerManager.PauseAndContinueGameAfterPlayerRespawn();
    }
}

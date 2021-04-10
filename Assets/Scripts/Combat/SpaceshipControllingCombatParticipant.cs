using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControllingCombatParticipant : CombatParticipant
{
    [SerializeField]
    private SpaceshipHealth _spaceshipHealth;
    [SerializeField]
    private SpaceshipController _spaceshipController;

    protected override bool CanReceiveHit(ICombatParticipant attackingCombatParticipant)
    {
        SpaceshipControllingCombatParticipant attackingSpaceship = attackingCombatParticipant as SpaceshipControllingCombatParticipant;

        if (attackingSpaceship != null)
        {
            return !attackingSpaceship.CompareTag(gameObject.tag);
        }
        return true;
    }

    protected override void ProceedWithHit(ICombatParticipant attackingCombatParticipant)
    {
        _spaceshipHealth.DecreaseNumberOfLives();
        _spaceshipController.ProcessSpaceshipHit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipControllingCombatParticipant : CombatParticipant
{
    private SpaceshipHealth _spaceshipHealth;
    private SpaceshipController _spaceshipController;

    private void Awake()
    {
        _spaceshipHealth = GetComponent<SpaceshipHealth>();
        _spaceshipController = GetComponent<SpaceshipController>();
    }

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

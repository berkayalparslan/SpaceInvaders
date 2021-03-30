using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : CombatParticipant
{
    [SerializeField]
    private AiSpaceshipController _aiSpaceship;
    protected override bool CanBeHit(ICombatParticipant combatParticipant)
    {
        return !IsHitBySameTypeOfObject(combatParticipant);
    }

    protected override void ProceedWithHit(ICombatParticipant combatParticipant)
    {
        _aiSpaceship.DestroySpaceship();
    }
}

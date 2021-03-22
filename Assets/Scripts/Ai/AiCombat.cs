using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : CombatParticipant
{
    protected override bool CanBeHit(ICombatParticipant combatParticipant)
    {
        return !IsHitBySameTypeOfObject(combatParticipant);
    }

    protected override void ProceedWithHit(ICombatParticipant combatParticipant)
    {
        gameObject.SetActive(false);
    }
}

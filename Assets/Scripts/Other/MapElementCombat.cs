using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElementCombat : CombatParticipant
{
    protected override bool CanBeHit(ICombatParticipant combatParticipant)
    {
        return (combatParticipant as MapElementCombat) == null;
    }

    protected override void ProceedWithHit(ICombatParticipant combatParticipant)
    {
        gameObject.SetActive(false);
    }
}

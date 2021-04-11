using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElementCombat : CombatParticipant
{
    protected override bool CanReceiveHit(ICombatParticipant combatParticipant)
    {
        return (combatParticipant as MapElementCombat) == null;
    }

    protected override void ProceedWithHit(ICombatParticipant combatParticipant)
    {
        if (!gameObject.CompareTag("MapBorder"))
        {
            gameObject.SetActive(false);
        }
    }
}

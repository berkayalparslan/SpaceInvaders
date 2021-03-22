using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatParticipant : MonoBehaviour, ICombatParticipant
{
    protected abstract bool CanBeHit(ICombatParticipant combatParticipant);
    protected abstract void ProceedWithHit(ICombatParticipant combatParticipant);

    
    public void ReceiveHit(ICombatParticipant combatParticipant)
    {
        if (CanBeHit(combatParticipant))
        {
            ProceedWithHit(combatParticipant);
        }
    }

    protected bool IsHitBySameTypeOfObject(ICombatParticipant combatParticipant)
    {
        return combatParticipant.GetType() == GetType();
    }
}

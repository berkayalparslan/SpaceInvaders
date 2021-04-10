using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatParticipant : MonoBehaviour, ICombatParticipant
{
    protected abstract bool CanReceiveHit(ICombatParticipant attackingCombatParticipant);
    protected abstract void ProceedWithHit(ICombatParticipant attackingCombatParticipant);

    
    public void ReceiveHit(ICombatParticipant attackingCombatParticipant)
    {
        if (CanReceiveHit(attackingCombatParticipant))
        {
            ProceedWithHit(attackingCombatParticipant);
        }
    }

    protected bool IsHitBySameTypeOfObject(ICombatParticipant attackingCombatParticipant)
    {
        return attackingCombatParticipant.GetType() == GetType();
    }
}

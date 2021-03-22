using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatParticipant
{
    void ReceiveHit(ICombatParticipant combatParticipant);
}

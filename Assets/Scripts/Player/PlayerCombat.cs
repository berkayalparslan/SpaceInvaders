using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : CombatParticipant
{
    public event UnityAction OnPlayerDeath;

    public ProjectileSender SenderType
    {
        get
        {
            return ProjectileSender.Player;
        }
    }

    protected override bool CanBeHit(ICombatParticipant combatParticipant)
    {
        return (combatParticipant as PlayerCombat) == null;
    }

    protected override void ProceedWithHit(ICombatParticipant combatParticipant)
    {
        gameObject.SetActive(false);

        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
    }

    private void Start()
    {
        OnPlayerDeath = new UnityAction(Managers.Instance.PlayerManager.OnPlayerDeath);
    }

    private void OnDestroy()
    {
        OnPlayerDeath -= Managers.Instance.PlayerManager.OnPlayerDeath;
    }

    
}

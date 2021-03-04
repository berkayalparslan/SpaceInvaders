using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour, IProjectileCombat
{
    public event UnityAction OnPlayerDeath;

    public ProjectileSender SenderType
    {
        get
        {
            return ProjectileSender.Player;
        }
    }

    public void ReceiveHit(IProjectileCombat combatSender)
    {
        if (combatSender.SenderType != ProjectileSender.Player)
        {
            gameObject.SetActive(false);

            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IProjectileCombat
{
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
        }
    }
}

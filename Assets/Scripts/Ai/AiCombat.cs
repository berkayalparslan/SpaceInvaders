using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : MonoBehaviour, IProjectileCombat
{
    public ProjectileSender SenderType
    {
        get
        {
            return ProjectileSender.Ai;
        }
    }

    public void ReceiveHit(IProjectileCombat combatSender)
    {
        if (combatSender.SenderType != ProjectileSender.Ai)
        {
            gameObject.SetActive(false);
        }
    }
}

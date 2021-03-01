using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElementCombat : MonoBehaviour, IProjectileCombat
{
    public ProjectileSender SenderType
    {
        get
        {
            return ProjectileSender.NONE;
        }
    }

    public void ReceiveHit(IProjectileCombat combatSender)
    {
        if (!gameObject.CompareTag("MapBorder"))
        {
            gameObject.SetActive(false);
        }
    }
}

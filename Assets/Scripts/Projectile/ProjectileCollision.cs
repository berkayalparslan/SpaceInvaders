using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private CombatParticipant _projectileSender;

    public CombatParticipant ProjectileSender
    {
        get
        {
            return _projectileSender;
        }
    }


    public void SetProjectileSender(CombatParticipant projectileSender)
    {
        _projectileSender = projectileSender;
    }

    private void OnDisable()
    {
        _projectileSender = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CombatParticipant hitCombatParticipant = collision.collider.GetComponent<CombatParticipant>();

        if (hitCombatParticipant != null)
        {
            hitCombatParticipant.ReceiveHit(_projectileSender);
        }
        else
        {
            collision.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}

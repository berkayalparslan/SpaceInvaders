using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private CollisionHandler _collisionHandler;
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

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _collisionHandler.OnCollisionEnterEvent.AddListener(OnProjectileCollision);
    }

    private void OnDisable()
    {
        _projectileSender = null;
    }

    private void OnProjectileCollision(Collider2D collider)
    {
        CombatParticipant hitCombatParticipant = collider.GetComponent<CombatParticipant>();

        if (hitCombatParticipant != null)
        {
            hitCombatParticipant.ReceiveHit(_projectileSender);
            gameObject.SetActive(false);
        }
        
    }
}

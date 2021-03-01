using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private CollisionHandler _collisionHandler;
    private IProjectileCombat _projectileSender;


    public void SetProjectileSender(IProjectileCombat projectileSender)
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
        IProjectileCombat hitCombatParticipant = collider.GetComponent<IProjectileCombat>();

        if (hitCombatParticipant != null)
        {
            hitCombatParticipant.ReceiveHit(_projectileSender);
            gameObject.SetActive(false);
        }
        
    }
}

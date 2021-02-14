using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private CollisionHandler _collisionHandler;
    private ProjectileSender _projectileSender;


    public void SetProjectileSenderType(ProjectileSender projectileSender)
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
        _projectileSender = ProjectileSender.NONE;
    }

    private void OnProjectileCollision(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (_projectileSender == ProjectileSender.Player)
            {
                collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        if (collider.CompareTag("Player"))
        {
            if (_projectileSender == ProjectileSender.Enemy)
            {
                collider.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}

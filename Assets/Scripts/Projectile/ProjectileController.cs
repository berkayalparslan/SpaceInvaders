using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private ProjectileCollision _projectileCollision;
    
    public void InitProjectile(CombatParticipant projectileSender, Vector3 position, Quaternion rotation)
    {
        _projectileCollision.SetProjectileSender(projectileSender);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void EnableObject()
    {
        gameObject.SetActive(true);
    }
}

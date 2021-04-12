using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private ProjectileCollision _projectileCollision;
    private CombatParticipant _projectileSender;
    
    public void InitProjectile(CombatParticipant projectileSender, Vector3 position, Quaternion rotation)
    {
        _projectileSender = projectileSender;
        _projectileCollision.SetProjectileSender(projectileSender);
        transform.position = position;
        transform.rotation = rotation;
    }

    public void EnableObject()
    {
        gameObject.SetActive(true);
        PlayShootingSound();
    }

    private void PlayShootingSound()
    {
        if (_projectileSender.CompareTag("Player"))
        {
            Managers.Instance.PlayerManager.PlayShootingSound();
        }
        else if (_projectileSender.CompareTag("Enemy"))
        {
            Managers.Instance.AiSpaceshipsRowManager.PlayShootingSound();
        }
    }
}

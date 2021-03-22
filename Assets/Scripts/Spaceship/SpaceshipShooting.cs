using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
    private const float _shootingCooldownDuration = 1f;
    private IInput _input;
    [SerializeField]
    private Transform _projectileReleasePoint;
    private float _shootingCooldown;


    private void Awake()
    {
        _input = GetComponent<IInput>();
    }

    private void Update()
    {
        _shootingCooldown -= Time.deltaTime;

        if (_shootingCooldown <= 0f)
        {
            if (_input.Firing)
            {
                _shootingCooldown = _shootingCooldownDuration;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        GameObject projectile = Managers.Instance.ProjectilesPool.GetPoolObject();

        if (projectile != null)
        {
            ProjectileCollision projectileCollision = projectile.GetComponent<ProjectileCollision>();
            CombatParticipant projectileSender = GetComponent<CombatParticipant>();

            if (projectileSender != null)
            {
                projectileCollision.SetProjectileSender(projectileSender);
                projectile.transform.position = _projectileReleasePoint.position;
                projectile.transform.rotation = _projectileReleasePoint.rotation;
                projectile.SetActive(true);
            }
        }
    }
}

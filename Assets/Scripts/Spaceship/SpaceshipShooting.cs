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
    private CombatParticipant _projectileSender;


    private void Awake()
    {
        _input = GetComponent<IInput>();
        _projectileSender = GetComponent<CombatParticipant>();
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
            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();

            if (projectileController != null)
            {
                projectileController.InitProjectile(_projectileSender, _projectileReleasePoint.position, _projectileReleasePoint.rotation);
                projectileController.EnableObject();
            }
        }
    }
}

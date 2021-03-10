using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShooting : MonoBehaviour
{
    private const float _minShootingCooldownTimeInSeconds = 1f;
    private const float _maxShootingCooldownTimeInSeconds = 12f;

    private float _shootingCooldownTimerInSeconds;
    private float _currentCooldownTimeInSeconds;
    private float _verticalDirection;
    
    public bool Fire { get; private set; }

    private void OnEnable()
    {
        SetCooldownTimeRandomly();
        UpdateVerticalDirection();
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        _shootingCooldownTimerInSeconds += Time.deltaTime;
        Fire = false;

        if (_shootingCooldownTimerInSeconds > _currentCooldownTimeInSeconds)
        {
            _shootingCooldownTimerInSeconds = 0f;
            if (CanFire())
            {
                SetCooldownTimeRandomly();
                Fire = true;
            }
        }
    }

    private void UpdateVerticalDirection()
    {
        _verticalDirection = (transform.rotation.eulerAngles.z + 360) % 360 == 180 ? -1f : 1f;
    }

    private void SetCooldownTimeRandomly()
    {
        _currentCooldownTimeInSeconds = Random.Range(_minShootingCooldownTimeInSeconds, _maxShootingCooldownTimeInSeconds);
    }

    private bool CanFire()
    {
        Vector2 rayDirection = Vector2.up * _verticalDirection;
        float rayDistance = 5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayDistance);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, rayDirection, Color.white);
#endif

        if (hit.transform != null && hit.transform.CompareTag("Enemy"))
        {
            return false;
        }
        return true;
    }
}

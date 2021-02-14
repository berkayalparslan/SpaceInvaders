using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiInput : MonoBehaviour, IInput
{
    private const float _maxDistanceFromStartingPosition = 3f;
    private Vector2 _startingPosition;
    private float _direction;
    private float _shootingTimer;

    public float HorizontalInput { get; private set; }
    public bool Firing { get; private set; }


    private void OnEnable()
    {
        _startingPosition = transform.position;
        HorizontalInput = 1f;
    }

    private void Update()
    {
        _shootingTimer += Time.deltaTime;

        if (_shootingTimer > 1f)
        {
            _shootingTimer = 0f;

            if (CanShoot())
            {
                Firing = true;
            }
        }
        if (Mathf.Abs(transform.position.x - _startingPosition.x) >= _maxDistanceFromStartingPosition)
        {
            HorizontalInput *= -1;
        }
    }

    private bool CanShoot()
    {
        _direction = (transform.rotation.eulerAngles.z + 360) % 360 == 180 ? -1f : 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * _direction,5f);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, Vector2.up * 1f, Color.white);
#endif

        if (hit.transform != null && hit.transform.CompareTag("Enemy"))
        {
            return false;
        }
        return true;
    }
}

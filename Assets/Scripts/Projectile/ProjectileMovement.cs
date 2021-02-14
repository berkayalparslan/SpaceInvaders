using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector3 _direction;
    [SerializeField]
    private float _speed;


    private void OnEnable()
    {
        _direction = (transform.eulerAngles.z + 360) % 360 == 180 ? Vector2.down :  Vector2.up;
    }

    private void Update()
    {
        transform.position += (_direction * Time.deltaTime * _speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    private Vector3 _position;
    [SerializeField]
    private float _speed;


    private void OnEnable()
    {
        _direction = (transform.eulerAngles.z + 360) % 360 == 180 ? Vector2.down :  Vector2.up;
        _position = _rigidbody2D.position;
    }

    private void FixedUpdate()
    {
        _position += (_direction * Time.deltaTime * _speed);
        _rigidbody2D.MovePosition(_position);
    }
}

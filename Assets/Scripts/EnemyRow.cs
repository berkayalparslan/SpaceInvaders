using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRow : MonoBehaviour
{
    private List<Transform> _enemies = new List<Transform>();
    private Vector2 _startingPosition;
    private Vector2 _currentPos;
    private float _maxDistanceChange;
    private float _movementSide;
    [SerializeField]
    private float _movementSpeed = 3f;


    private void Awake()
    {
        _startingPosition = transform.position;
        _currentPos = _startingPosition;

        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i));
        }
    }
}

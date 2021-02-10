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


    public void StartHorizontalMovement(float maxDistanceChange, float startingMovementSide)
    {
        _maxDistanceChange = maxDistanceChange;
        _movementSide = startingMovementSide;
        StartCoroutine(MoveRowHorizontally());
    }

    private void Awake()
    {
        _startingPosition = transform.position;
        _currentPos = _startingPosition;

        for (int i = 0; i < transform.childCount; i++)
        {
            _enemies.Add(transform.GetChild(i));
        }
    }

    private IEnumerator MoveRowHorizontally()
    {
        while (_enemies.Count > 0)
        {
            if (Mathf.Abs(transform.position.x - _startingPosition.x) >= _maxDistanceChange)
            {
                _movementSide *= -1;
            }
            _currentPos += Vector2.right * _movementSide * Time.deltaTime * _movementSpeed;
            _currentPos.x = Mathf.Clamp(_currentPos.x, _startingPosition.x - _maxDistanceChange, _startingPosition.x + _maxDistanceChange);
            transform.position = _currentPos;
            yield return new WaitForEndOfFrame();
        }
    }
}

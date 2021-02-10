using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRowsEntity : MonoBehaviour
{
    private const float _maxHorizontalMovementDistance = 3f;
    private List<EnemyRow> _enemyRows = new List<EnemyRow>();


    void Start()
    {
        _enemyRows.AddRange(GetComponentsInChildren<EnemyRow>());
        StartMovingEnemyRows();
    }


    private void StartMovingEnemyRows()
    {
        for (int i = 0; i < _enemyRows.Count; i++)
        {
            _enemyRows[i].StartHorizontalMovement(_maxHorizontalMovementDistance, i % 2 == 0 ? -1 : 1);
        }
    }
}

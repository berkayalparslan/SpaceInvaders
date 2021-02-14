using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRowsEntity : MonoBehaviour
{
    private List<EnemyRow> _enemyRows = new List<EnemyRow>();


    private void Start()
    {
        _enemyRows.AddRange(GetComponentsInChildren<EnemyRow>());
    }
}

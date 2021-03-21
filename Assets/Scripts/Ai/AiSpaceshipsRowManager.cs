using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRowManager : MonoBehaviour
{
    private List<AiSpaceshipsRow> _rows = new List<AiSpaceshipsRow>();

    private void Awake()
    {
        Managers.Instance.GameManager.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        Managers.Instance.GameManager.OnGameStart -= OnGameStart;
        _rows.AddRange(GetComponentsInChildren<AiSpaceshipsRow>());

        foreach (AiSpaceshipsRow row in _rows)
        {
            row.InitRow();
        }
    }
}

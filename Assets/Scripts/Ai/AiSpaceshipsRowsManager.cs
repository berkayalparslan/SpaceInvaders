using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRowsManager : MonoBehaviour
{
    private List<AiSpaceshipsRowController> _rows = new List<AiSpaceshipsRowController>();
    private int _numberOfSpaceshipsPerRow;
    private const short _numberOfLivesForAiSpaceships = 1;

    public void SetNumberOfSpaceshipsPerRow()
    {
        _numberOfSpaceshipsPerRow = Managers.Instance.UiManager.UiGameSettings.NumberOfSpaceshipsPerRow;
    }

    private void Awake()
    {
        Managers.Instance.GameManager.OnGameStart += OnGameStart;
    }

    private void OnGameStart()
    {
        Managers.Instance.GameManager.OnGameStart -= OnGameStart;
        _rows.AddRange(GetComponentsInChildren<AiSpaceshipsRowController>());

        foreach (AiSpaceshipsRowController row in _rows)
        {
            row.InitRow(_numberOfSpaceshipsPerRow, _numberOfLivesForAiSpaceships);
        }
    }
}

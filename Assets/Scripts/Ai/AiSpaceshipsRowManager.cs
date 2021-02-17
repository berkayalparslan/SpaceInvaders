using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRowManager : MonoBehaviour
{
    private List<AiSpaceshipsRow> _rows = new List<AiSpaceshipsRow>();
    private int _aiSpaceshipsCountInScene = 0;


    public void DecreaseSpaceshipCount()
    {
        _aiSpaceshipsCountInScene--;
    }

    private void Start()
    {
        _rows.AddRange(GetComponentsInChildren<AiSpaceshipsRow>());
        foreach (AiSpaceshipsRow row in _rows)
        {
            row.InitRow();
            _aiSpaceshipsCountInScene += row.SlotsCount;
        }
    }
}

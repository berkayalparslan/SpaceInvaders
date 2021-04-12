using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSpaceshipsRowsManager : MonoBehaviour
{
    private const short _numberOfLivesForAiSpaceships = 1;
    private List<AiSpaceshipsRowController> _rows = new List<AiSpaceshipsRowController>();
    private int _numberOfSpaceshipsPerRow;
    private SpaceshipSound _aiSpaceshipSound;

    public void SetNumberOfSpaceshipsPerRow()
    {
        _numberOfSpaceshipsPerRow = Managers.Instance.UiManager.UiGameSettings.NumberOfSpaceshipsPerRow;
    }

    public void PlayExplosionSound()
    {
        _aiSpaceshipSound.PlayExplosionSound();
    }

    public void PlayShootingSound()
    {
        _aiSpaceshipSound.PlayShootingSound();
    }

    private void Awake()
    {
        Managers.Instance.GameManager.OnGameStart += OnGameStart;
        _aiSpaceshipSound = GetComponent<SpaceshipSound>();
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

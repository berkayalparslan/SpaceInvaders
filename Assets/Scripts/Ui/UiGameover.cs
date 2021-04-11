using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UiGameover : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _restartInfoText;
    [SerializeField]
    private TMP_Text _playerScoreText;
    [SerializeField]
    private TMP_Text _playerHighestScoreText;
    [SerializeField]
    private TMP_Text _playerHasNewHighestScoreText;
    [SerializeField]
    private GameObject _escapeMenuButton;


    public void ShowPlayerScoreAndHighScore(int score, int highestScore)
    {
        bool playerHasNewHighestScore = score > highestScore;
        int playerHighestScore = playerHasNewHighestScore ? score : highestScore;

        if (playerHasNewHighestScore)
        {
            _playerHasNewHighestScoreText.gameObject.SetActive(true); 
        }

        _playerScoreText.text = score.ToString();
        _playerHighestScoreText.text = playerHighestScore.ToString();

        _escapeMenuButton.SetActive(false);
        gameObject.SetActive(true);
    }
}

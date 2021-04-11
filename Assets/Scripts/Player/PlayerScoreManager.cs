using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScoreManager: MonoBehaviour
{
    public event UnityAction<int> OnScoreChanged;
    private const string _highestScoreKey = "HighestScore";
    private const float _scoreGainForKillMultiplier = 2f;
    private const float _scoreLoseForReceivingHit = 5f;
    private float _score = 0;
    private int _scoreRoundedToInt;
    private int _highestScore;
    private float _playerSpeedScoreMultiplier;
    private float _numberOfEnemiesScoreMultiplier;

    public int Score
    {
        get
        {
            _scoreRoundedToInt = Mathf.RoundToInt(_score);
            return _scoreRoundedToInt;
        }
    }
    public int HighestScore
    {
        get
        {
            return _highestScore;
        }
    }


    private void Awake()
    {
        ReadHighestScore();
    }

    private void OnDisable()
    {
        OnScoreChanged = null;
    }

    public void SetScoreMultipliers(float playerSpeed, int numberOfAiSpaceships)
    {
        //lower player speed gives higher score
        _playerSpeedScoreMultiplier = 10f - (playerSpeed - 1) * 2.5f;
        //more enemies give higher score
        _numberOfEnemiesScoreMultiplier = Mathf.Pow(2, numberOfAiSpaceships);
    }

    public void AddScoreForKill()
    {
        _score += _scoreGainForKillMultiplier * (_playerSpeedScoreMultiplier + _numberOfEnemiesScoreMultiplier);

        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }

    public void SubScoreForReceivingHit()
    {
        _score -= _scoreLoseForReceivingHit * (_playerSpeedScoreMultiplier + _numberOfEnemiesScoreMultiplier);

        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }

    public void SaveIfPlayerAchievedNewHighestRecord()
    {
        if (AchievedNewHighestScore())
        {
            PlayerPrefs.SetInt(_highestScoreKey, _scoreRoundedToInt);
        }
    }

    private bool AchievedNewHighestScore()
    {
        return _scoreRoundedToInt > _highestScore;
    }

    private void ReadHighestScore()
    {
        if (PlayerPrefs.HasKey(_highestScoreKey))
        {
            _highestScore = PlayerPrefs.GetInt(_highestScoreKey);
        }
        else
        {
            _highestScore = 0;
        }
    }
}

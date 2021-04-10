using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealth : MonoBehaviour
{
    private short _lives;

    public bool IsAlive
    {
        get
        {
            return _lives > 0;
        }
    }
    
    public void SetNumberOfLives(short numberOfLives)
    {
        _lives = numberOfLives;
    }

    public void DecreaseNumberOfLives()
    {
        _lives--;
    }
}

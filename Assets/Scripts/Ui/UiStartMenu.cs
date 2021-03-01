using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiStartMenu : MonoBehaviour
{
    [SerializeField]
    private Button _startGameButton;

    public Button StartGameButton
    {
        get
        {
            return _startGameButton;
        }
    }
}

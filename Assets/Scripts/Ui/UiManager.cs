using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public UiSpaceshipSelection UiSpaceshipSelection;
    public UiSpaceshipColorSelection UiSpaceshipColorSelection;
    public UiSpaceshipTypeSelection UiSpaceshipTypeSelection;
    public UiStartMenu UiStartMenu;

    [SerializeField]
    private GameObject MainMenuCanvas;

    public void HideMainMenu()
    {
        MainMenuCanvas.SetActive(false);
    }
}

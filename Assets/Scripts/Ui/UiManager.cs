using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public UiSpaceshipSelection UiSpaceshipSelection;
    public UiSpaceshipColorSelection UiSpaceshipColorSelection;
    public UiSpaceshipTypeSelection UiSpaceshipTypeSelection;
    public UiGameSettings UiGameSettings;
    public UiEscapeMenu UiEscapeMenu;
    public UiPlayerHud UiPlayerHud;
    public UiGameover UiGameover;

    [SerializeField]
    private GameObject _mainMenuCanvas;
    [SerializeField]
    private GameObject _ingameHudCanvas;
    [SerializeField]
    private GameObject _escapeMenuCanvas;

    public void HideMainMenu()
    {
        _mainMenuCanvas.SetActive(false);
    }

    public void ShowIngameHud()
    {
        _ingameHudCanvas.SetActive(true);
    }

    public void EnableEscapeMenuCanvas()
    {
        _escapeMenuCanvas.SetActive(true);
    }

    public void ShowEscapeMenu()
    {
        UiEscapeMenu.gameObject.SetActive(true);
    }

    public void HideEscapeMenu()
    {
        UiEscapeMenu.gameObject.SetActive(false);
    }
}

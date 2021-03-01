using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public UiSpaceshipColorButtons UiSpaceshipColorButtons;
    public UiSpaceshipTypeSelection UiSpaceshipTypeSelection;
    public UiStartMenu UiStartMenu; 


    public void HideMainMenuUi()
    {
        UiSpaceshipColorButtons.gameObject.SetActive(false);
        UiSpaceshipTypeSelection.gameObject.SetActive(false);
        UiStartMenu.gameObject.SetActive(false);
    }
}

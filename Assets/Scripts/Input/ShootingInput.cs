using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingInput : MonoBehaviour
{
    public bool Firing { get; protected set; }

    protected abstract void UpdateShootingInput();

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameIsRunning)
        {
            return;
        }

        UpdateShootingInput();
    }
}

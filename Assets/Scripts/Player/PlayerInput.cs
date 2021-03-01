using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    private float _horizontalInput;
    private bool _firing;

    public float HorizontalInput
    {
        get
        {
            return _horizontalInput;
        }
    }

    public bool Firing
    {
        get
        {
            return _firing;
        }
    }

    private void Update()
    {
        if (!Managers.Instance.GameManager.GameStarted)
        {
            return;
        }

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _firing = Input.GetKey(KeyCode.Space);
    }
}

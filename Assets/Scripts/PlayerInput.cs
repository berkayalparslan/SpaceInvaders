using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
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


    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _firing = Input.GetKey(KeyCode.Space);
    }
}

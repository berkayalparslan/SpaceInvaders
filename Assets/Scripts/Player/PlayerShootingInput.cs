using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingInput : ShootingInput
{
    protected override void UpdateShootingInput()
    {
        Firing = Input.GetKey(KeyCode.Space);
    }
}

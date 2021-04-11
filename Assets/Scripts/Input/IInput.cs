using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    float HorizontalInput { get; }
    float VerticalInput { get; }
    bool Firing { get; }
}

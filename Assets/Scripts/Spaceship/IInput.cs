using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    float HorizontalInput { get; }
    bool Firing { get; }
}

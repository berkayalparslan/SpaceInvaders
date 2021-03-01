using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileCombat
{
    ProjectileSender SenderType { get; }
    void ReceiveHit(IProjectileCombat projectileSender);
}

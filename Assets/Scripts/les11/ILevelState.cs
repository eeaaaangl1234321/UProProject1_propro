using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelState
{
    void Enter();
    void Do();
    void FixedDo();
    void Exit();
}

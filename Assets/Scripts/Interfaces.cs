using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public delegate void StateEvent(Type newStateType);

public interface IState
{
    public void Enter(IStateRunner owner);
    public void Execute(IStateRunner owner);
    public void Exit(IStateRunner owner);
    StateEvent onSwitch { get; set; }
}

public interface IStateRunner
{
    public float speed { get; set; }
}

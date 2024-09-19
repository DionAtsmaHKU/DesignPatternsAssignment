using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Enter(IStateRunner owner);
    public void Execute(IStateRunner owner);
    public void Exit(IStateRunner owner);
}

public interface IStateRunner
{

}

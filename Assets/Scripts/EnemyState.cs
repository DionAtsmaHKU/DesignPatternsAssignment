using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public abstract class EnemyState : IState
{
    public virtual void Enter(IStateRunner owner) { }
    public virtual void Execute(IStateRunner owner) { }
    public virtual void Exit(IStateRunner owner) { }
    public StateEvent onSwitch { get; set; }
}

public class EnemyIdleState : EnemyState
{
    private float timer;

    public override void Enter(IStateRunner owner) 
    {
        Debug.Log("Entering Idle State");
        timer = 0;
    }
    public override void Execute(IStateRunner owner) 
    {
        timer += Time.deltaTime;
        Debug.Log("In Idle State");
        if (timer > 3)
        {
            onSwitch.Invoke(typeof(EnemyAttackState));
        }
    }
    public override void Exit(IStateRunner owner) { }
}



public class EnemyAttackState : EnemyState
{
    public override void Enter(IStateRunner owner) 
    {
        Debug.Log("Entering Attack State");
        owner.speed = 5;
    }
    public override void Execute(IStateRunner owner)
    {
        // Move Enemy somehow
        Debug.Log("In Attack State");
    }
    public override void Exit(IStateRunner owner) { }
}

/*
 
public class EnemyPatrolState : EnemyState
{
    public override void Enter(FSM owner) { }
    public override void Execute(FSM owner) { }
    public override void Exit(FSM owner) { }
}
*/
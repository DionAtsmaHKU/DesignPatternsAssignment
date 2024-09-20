using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class FSM
{
    protected IStateRunner owner;
    private IState currentState;
    protected Dictionary<Type, IState> states;

    public FSM(Type ownerType, IStateRunner ownerInterface)
    {
        owner = ownerInterface;
        states = new Dictionary<Type, IState>();
        Debug.Log("FSM constructor");
        if (true) // Check if it is an enemy ?? aghaerahr
        {
            InitializeEnemy();
        }
    }

    private void InitializeEnemy()
    {
        Debug.Log("Enemy Init");
        states.Add(typeof(EnemyIdleState), new EnemyIdleState());
        states.Add(typeof(EnemyAttackState), new EnemyAttackState());
       // states.Add(typeof(EnemyPatrolState), new EnemyPatrolState());

        currentState = states[typeof(EnemyIdleState)];
        currentState.onSwitch += ChangeState;
        currentState.Enter(owner);
        
    }

    public void Execute()
    {
        if (currentState != null)
        {
            currentState.Execute(owner);
        }
    }

    public void ChangeState(Type newStateType)
    {
        if (currentState != null)
        {
            currentState.Exit(owner);
            currentState.onSwitch -= ChangeState;
        }
        currentState = states[newStateType];

        currentState.Enter(owner);
        currentState.onSwitch += ChangeState;
    }

    /*
    public void ChangeState(Type newStateType)
    {
        currentState?.Exit(owner);
        
        currentState?.Enter(owner);
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class FSM<T>
{
    protected IStateRunner owner;
    private IState currentState;
    protected Dictionary<Type, IState> states;

    public FSM(T ownerType, IStateRunner ownerInterface)
    {
        owner = ownerInterface;
        states = new Dictionary<Type, IState>();
        if (ownerType.GetType() == typeof(Enemy))
        {
            InitializeEnemy();
        }
    }

    private void InitializeEnemy()
    {
        states.Add(typeof(EnemyIdleState), new EnemyIdleState());
        states.Add(typeof(EnemyPatrolState), new EnemyPatrolState());
        states.Add(typeof(EnemyAttackState), new EnemyAttackState());

        currentState = states[typeof(EnemyIdleState)];
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
        currentState?.Exit(owner);
        currentState = states[newStateType];
        currentState?.Enter(owner);
    }
}

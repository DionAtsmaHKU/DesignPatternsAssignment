using System.Collections.Generic;
using System;
public class FSM
{
    protected IStateRunner owner;
    protected Dictionary<Type, IState> states;

    private IState currentState;

    public FSM(IStateRunner ownerInterface)
    {
        owner = ownerInterface;
        states = new Dictionary<Type, IState>();

        // I couldn't figure out how to specifically figure out whether this owner is of type Enemy,
        // so for convenience i set this condition to always be true.
        if (true) 
        {
            InitializeEnemy();
        }
    }

    // Method for inatializing an Enemy class with a FSM.
    private void InitializeEnemy()
    {
        states.Add(typeof(EnemyIdleState), new EnemyIdleState());
        states.Add(typeof(EnemyAttackState), new EnemyAttackState());

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
}

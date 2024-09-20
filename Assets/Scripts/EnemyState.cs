using UnityEngine;

public abstract class EnemyState : IState
{
    public virtual void Enter(IStateRunner owner) { }
    public virtual void Execute(IStateRunner owner) { }
    public virtual void Exit(IStateRunner owner) { }
    public StateEvent onSwitch { get; set; }
}

// Idle state, Enemy waits, then changes to Attack state.
public class EnemyIdleState : EnemyState
{
    private float timer;

    public override void Enter(IStateRunner owner) 
    {
        timer = 0;
    }

    public override void Execute(IStateRunner owner) 
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            onSwitch.Invoke(typeof(EnemyAttackState));
        }
    }

    public override void Exit(IStateRunner owner) { }
}

// Attack State, enemy starts moving
public class EnemyAttackState : EnemyState
{
    public override void Enter(IStateRunner owner) 
    {
        owner.speed = 5;
    }

    public override void Execute(IStateRunner owner)
    {
        // Other potential behaviour here
    }

    public override void Exit(IStateRunner owner) { }
}

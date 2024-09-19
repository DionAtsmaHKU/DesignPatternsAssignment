using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : IState
{
    public virtual void Enter(IStateRunner owner) { }
    public virtual void Execute(IStateRunner owner) { }
    public virtual void Exit(IStateRunner owner) { }

}

public class EnemyIdleState : EnemyState
{
    public override void Enter(IStateRunner owner) { }
    public override void Execute(IStateRunner owner) { }
    public override void Exit(IStateRunner owner) { }
}

public class EnemyPatrolState : EnemyState
{
    public override void Enter(IStateRunner owner) { }
    public override void Execute(IStateRunner owner) { }
    public override void Exit(IStateRunner owner) { }
}

public class EnemyAttackState : EnemyState
{
    public override void Enter(IStateRunner owner) { }
    public override void Execute(IStateRunner owner) { }
    public override void Exit(IStateRunner owner) { }
}

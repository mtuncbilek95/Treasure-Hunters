using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EnemyIdleState : EnemyIdleState
{
    private Crabby_EntityScript crabbyEntityScript;
    public Crabby_EnemyIdleState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Crabby_EntityScript crabbyEntity) : base(entity, stateMachine, animationBoolName)
    {
        this.crabbyEntityScript = crabbyEntity;
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        crabbyEntityScript.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (crabbyEntityScript.EnemyCheck())
        {
            if (Time.time >= startTime + attackIdleTime)
            {
                stateMachine.ChangeState(crabbyEntityScript.CrabbyAttackState);
            }
        }
        else if (!crabbyEntityScript.LedgeCheck())
        {
            RandomFlip();
        }

        else if (crabbyEntityScript.LedgeCheck())
        {
            stateMachine.ChangeState(crabbyEntityScript.CrabbyMoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

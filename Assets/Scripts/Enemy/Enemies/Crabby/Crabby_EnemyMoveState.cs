using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EnemyMoveState : EnemyMoveState
{
    private Crabby_EntityScript crabbyEntityScript;

    public Crabby_EnemyMoveState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Crabby_EntityScript crabbyEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.crabbyEntityScript = crabbyEntityScript;
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
            stateMachine.ChangeState(crabbyEntityScript.CrabbyIdleState);
        }
        else if (crabbyEntityScript.LedgeCheck())
        {
            crabbyEntityScript.SetVelocityX(5f * crabbyEntityScript.FacingDirection);
        }
        else if (!crabbyEntityScript.LedgeCheck())
        {
            stateMachine.ChangeState(crabbyEntityScript.CrabbyIdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

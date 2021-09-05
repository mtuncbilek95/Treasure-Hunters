using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EnemyHurtState : EnemyHurtState
{
    private Crabby_EntityScript crabbyEntityScript;
    private int hitDirection;
    public Crabby_EnemyHurtState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Crabby_EntityScript crabbyEntityScript) : base(entity, stateMachine, animationBoolName)
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
        crabbyEntityScript.SetVelocityX(0f);
        hitDirection = PlayerScript.FacingDirection;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        crabbyEntityScript.SetVelocityX(1f * hitDirection);
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(crabbyEntityScript.CrabbyIdleState);
        }
        else if (entity.EnemyHealth <= 0)
        {
            stateMachine.ChangeState(crabbyEntityScript.CrabbyDeadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

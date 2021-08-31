using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    public PlayerAttackState(PlayerScript player, EventListener checkScript, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName) : base(player, checkScript, stateMachine, playerData, animationBoolName)
    {
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
        if (attackCounter >= 3)
        {
            attackCounter = 0;
        }
        player.SetVelocityX(0f);
        player.Animator.SetInteger("attackCounter", attackCounter);
    }

    public override void Exit()
    {
        base.Exit();
        attackCounter++;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

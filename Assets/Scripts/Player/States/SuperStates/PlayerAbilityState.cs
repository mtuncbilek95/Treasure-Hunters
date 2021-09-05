using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool groundCheck;
    protected bool isAbilityDone;
    
    protected int xInput;

    public PlayerAbilityState(PlayerScript player, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
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
        groundCheck = player.GroundCheck();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
        if (player.attackCounter >= 3)
        {
            player.attackCounter = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.PlayerInput.NormXInput;

        if (isAbilityDone)
        {
            if (groundCheck && player.CurrentVelocity.y < 0.01f)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

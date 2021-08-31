using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;

    protected bool groundCheck;
    protected bool jumpInput;
    protected bool attackInput;
    protected bool interactInput;
    protected bool throwInput;

    public PlayerGroundedState(PlayerScript player, EventListener checkScript, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName) : base(player, checkScript, stateMachine, playerData, animationBoolName)
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
        player.JumpState.ResetJumps();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.PlayerInput.NormXInput;
        jumpInput = player.PlayerInput.JumpInput;
        attackInput = player.PlayerInput.AttackInput;
        interactInput = player.PlayerInput.InteractInput;
        throwInput = player.PlayerInput.ThrowInput;

        if(interactInput && player.canTakeSword)
        {
            eventListener.takeSword?.Invoke();
            eventListener.haveSword = 1;
        }
        else if (groundCheck && throwInput && eventListener.haveSword == 1)
        {
            stateMachine.ChangeState(player.ThrowSwordState);
            eventListener.haveSword = -1;
        }

        else if(groundCheck && attackInput && eventListener.haveSword == 1)
        {
            stateMachine.ChangeState(player.AttackState);
        }

        else if (!groundCheck)
        {
            stateMachine.ChangeState(player.InAirState);
        }

        else if(jumpInput && player.JumpState.CanJump())
        {
            player.PlayerInput.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected void AttackCounterReset()
    {
        if (Time.time >= startTime + 1f)
        {
            attackCounter = 0;
        }
    }
}

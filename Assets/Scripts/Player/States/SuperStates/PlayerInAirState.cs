using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    protected bool groundCheck;
    protected bool jumpInput;
    protected bool jumpInputStop;
    protected bool attackInput;
    public bool isJumping;

    protected int xInput;

    public PlayerInAirState(PlayerScript player, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
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
        jumpInputStop = player.PlayerInput.JumpInputStop;
        attackInput = player.PlayerInput.AttackInput;

        CheckJumpMultiplier();

        if (groundCheck && player.RB.velocity.y < 0.1f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(playerData.maximumSpeed * xInput);
            player.Animator.SetFloat("Yvelocity", player.CurrentVelocity.y);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.jumpMultiplier);
                isJumping = false;
            }

            else if (player.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }
    public void SetIsJumping() => isJumping = true;
}

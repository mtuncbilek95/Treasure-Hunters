using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int jumpValue;

    public PlayerJumpState(PlayerScript player, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
        jumpValue = playerData.jumpCount;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        jumpValue--;
        isAbilityDone = true;
        player.SetVelocityY(playerData.jumpSpeed);
        player.InAirState.SetIsJumping();
    }
    public bool CanJump()
    {
        if(jumpValue > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumps() => jumpValue = playerData.jumpCount;
}

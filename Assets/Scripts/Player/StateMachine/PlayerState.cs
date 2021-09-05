using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerScript player;
    public PlayerStateMachine stateMachine;
    public PlayerDataScript playerData;

    public static bool idleState, moveState, inAirState, landState, attackState, inAirAttackState, throwState, hurtState, deadState;

    public string animationBoolName;

    public float startTime;

    public bool isAnimationFinished;
    public bool canTakeSword;

    protected PlayerState(PlayerScript player, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        isAnimationFinished = false;
        startTime = Time.time;
        player.Animator.SetBool(animationBoolName, true);
        SetStateBool(animationBoolName, true);
        player.Animator.SetInteger("attackCounter", player.attackCounter);

    }
    public virtual void Exit()
    {
        player.Animator.SetBool(animationBoolName, false);
        SetStateBool(animationBoolName, false);

    }
    public virtual void LogicUpdate()
    {
        player.Animator.SetFloat("haveSword", player.haveSword);
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {
    }
    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishedTrigger() => isAnimationFinished = true;
    private static void SetStateBool(string stateCheckName, bool checkState)
    {
        switch (stateCheckName)
        {
            case "idleState":
                idleState = checkState;
                break;
            case "moveState":
                moveState = checkState;
                break;
            case "inAirState":
                inAirState = checkState;
                break;
            case "groundedState":
                landState = checkState;
                break;
            case "attackState":
                attackState = checkState;
                break;
            case "inAirAttackState":
                inAirAttackState = checkState;
                break;
            case "throwState":
                throwState = checkState;
                break;
            case "hurtState":
                hurtState = checkState;
                break;
            case "deadState":
                deadState = checkState;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerScript player;
    public PlayerStateEventTrigger checkScript;
    public PlayerStateMachine stateMachine;
    public PlayerDataScript playerData;

    public string animationBoolName;

    public float startTime;

    public bool isAnimationFinished;

    protected PlayerState(PlayerScript player, PlayerStateEventTrigger checkScript, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName)
    {
        this.player = player;
        this.checkScript = checkScript;
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
        checkScript.StateCheck(animationBoolName, true);
    }
    public virtual void Exit()
    {
        player.Animator.SetBool(animationBoolName, true);
        checkScript.StateCheck(animationBoolName, false);
    }
    public virtual void LogicUpdate()
    {

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

}

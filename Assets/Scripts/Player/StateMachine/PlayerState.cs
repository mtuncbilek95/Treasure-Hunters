using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerScript player;
    public EventListener eventListener;
    public PlayerStateMachine stateMachine;
    public PlayerDataScript playerData;

    public string animationBoolName;

    public float startTime;
    public float counterReset = 0.3f;

    public bool isAnimationFinished;

    public int attackCounter;


    protected PlayerState(PlayerScript player, EventListener checkScript, PlayerStateMachine stateMachine, PlayerDataScript playerData, string animationBoolName)
    {
        this.player = player;
        this.eventListener = checkScript;
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

    }
    public virtual void Exit()
    {
        player.Animator.SetBool(animationBoolName, false);

    }
    public virtual void LogicUpdate()
    {
        player.Animator.SetFloat("haveSword", eventListener.haveSword);

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

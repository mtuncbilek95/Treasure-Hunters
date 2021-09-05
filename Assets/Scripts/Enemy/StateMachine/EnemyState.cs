using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyScript entity;
    protected EnemyStateMachine stateMachine;

    protected float startTime;
    protected string animationBoolName;
    protected bool isAnimationFinished;


    public bool canTakeDamage;

    protected EnemyState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        isAnimationFinished = false;
        entity.Animator.SetBool(animationBoolName, true);
        startTime = Time.time;
        TakeDamageCheck();
    }
    public virtual void Exit()
    {
        entity.Animator.SetBool(animationBoolName, false);
        
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
    private void TakeDamageCheck()
    {
        if (animationBoolName != "hurtState" || animationBoolName != "deadState")
        {
            canTakeDamage = true;
        }
        else
        {
            canTakeDamage = false;
        }
    }

}

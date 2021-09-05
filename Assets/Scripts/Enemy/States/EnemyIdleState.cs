using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected float flipIdleTime;
    protected float attackIdleTime;
    public EnemyIdleState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        FlipIdleTime();
        AttackIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    private float AttackIdleTime()
    {
        return attackIdleTime = Random.Range(0.1f, 0.3f);
    }
    private float FlipIdleTime()
    {
        return flipIdleTime = Random.Range(0.2f, 2f);
    }
    protected void RandomFlip()
    {
        if(Time.time >= startTime + flipIdleTime)
        {
            entity.Flip();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seashell_EnemyDeadState : EnemyDeadState
{
    private Seashell_EntityScript seashellEntityScript;
    public Seashell_EnemyDeadState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Seashell_EntityScript seashellEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.seashellEntityScript = seashellEntityScript;
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

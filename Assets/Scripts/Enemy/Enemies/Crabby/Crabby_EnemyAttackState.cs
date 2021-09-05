using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EnemyAttackState : EnemyAttackState
{
    private Crabby_EntityScript crabbyEntityScript;
    public Crabby_EnemyAttackState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Crabby_EntityScript crabbyEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.crabbyEntityScript = crabbyEntityScript;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(crabbyEntityScript.CrabbyIdleState);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seashell_EnemyHurtState : EnemyHurtState
{
    private Seashell_EntityScript seashellEntityScript;
    public Seashell_EnemyHurtState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Seashell_EntityScript seashellEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.seashellEntityScript = seashellEntityScript;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(seashellEntityScript.SeashellIdleState);
        }
    }

}

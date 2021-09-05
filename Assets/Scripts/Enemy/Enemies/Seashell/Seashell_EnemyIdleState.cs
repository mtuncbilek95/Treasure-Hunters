using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seashell_EnemyIdleState : EnemyIdleState
{
    private Seashell_EntityScript seashellEntityScript;
    private float timer;
    public Seashell_EnemyIdleState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Seashell_EntityScript seashellEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.seashellEntityScript = seashellEntityScript;
    }

    public override void Enter()
    {
        base.Enter();
        SetAttackTimer();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (seashellEntityScript.EnemyCheck())
        {
            if(Time.time >= startTime + timer)
            {
                stateMachine.ChangeState(seashellEntityScript.SeashellAttackState);
            }
        }
        else if (seashellEntityScript.EnemyHealth <= 0)
        {
            stateMachine.ChangeState(seashellEntityScript.SeashellOpenState);
        }
    }

    private void SetAttackTimer()
    {
        timer = Random.Range(0.25f, 0.75f);
    }
}

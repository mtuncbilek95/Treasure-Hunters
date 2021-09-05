using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName) : base(entity, stateMachine, animationBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        canTakeDamage = true;
    }
}

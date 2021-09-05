using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EnemyDeadState : EnemyDeadState
{
    private Crabby_EntityScript crabbyEntityScript;
    public Crabby_EnemyDeadState(EnemyScript entity, EnemyStateMachine stateMachine, string animationBoolName, Crabby_EntityScript crabbyEntityScript) : base(entity, stateMachine, animationBoolName)
    {
        this.crabbyEntityScript = crabbyEntityScript;
    }
}

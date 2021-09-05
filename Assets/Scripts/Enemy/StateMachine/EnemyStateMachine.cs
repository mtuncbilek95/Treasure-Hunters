using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void ChangeState(EnemyState currentState)
    {
        CurrentState.Exit();

        CurrentState = currentState;
        CurrentState.Enter();
    }
}

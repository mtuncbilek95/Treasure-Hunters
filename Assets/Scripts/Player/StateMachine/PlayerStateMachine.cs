using UnityEngine;
public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState newState)
    {
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState changeState)
    {
        CurrentState.Exit();

        CurrentState = changeState;
        CurrentState.Enter();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStateEventTrigger : MonoBehaviour
{
    public string StateCheckName { get; private set; }

    public List<AnimatorControllerParameter> AnimatorControllers;

    public bool haveSword, idleState, moveState, inAirState, landState, attackState, inAirAttackState, throwState, hurtState, deadState; 

    public void Start()
    {

    }
    private void Update()
    {
    }
    public void StateCheck(string stateCheckName, bool checkState)
    {
        switch (stateCheckName)
        {
            case "idleState":
                idleState = checkState;
                break;
            case "moveState":
                moveState = checkState;
                break;
            case "inAirState":
                inAirState = checkState;
                break;
            case "groundedState":
                landState = checkState;
                break;
            case "attackState":
                attackState = checkState;
                break;
            case "inAirAttackState":
                inAirAttackState = checkState;
                break;
            case "throwState":
                throwState = checkState;
                break;
            case "hurtState":
                hurtState = checkState;
                break;
            case "deadState":
                deadState = checkState;
                break;
        }
    }
}

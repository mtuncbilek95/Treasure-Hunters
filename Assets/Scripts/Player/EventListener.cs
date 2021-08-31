using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public string StateCheckName { get; private set; }

    public int haveSword;

    public static bool idleState, moveState, inAirState, landState, attackState, inAirAttackState, throwState, hurtState, deadState;

    public UnityEvent takeSword;
    public UnityEvent throwSword;

    private void Start()
    {
        haveSword = -1;    
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

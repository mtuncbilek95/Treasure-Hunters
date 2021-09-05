using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineToAnimation : MonoBehaviour
{
    public EnemyScript enemyScript { get; private set; }

    private void Start()
    {
        enemyScript = GetComponentInParent<EnemyScript>();    
    }

    private void AnimationFinishTrigger() => enemyScript.AnimationFinishedTriggerFunction();
}

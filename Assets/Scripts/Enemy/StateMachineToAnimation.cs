using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineToAnimation : MonoBehaviour
{
    public EnemyScript enemyScript { get; private set; }
    public Seashell_EntityScript seashellScript { get; private set; }
    private void Start()
    {
        enemyScript = GetComponentInParent<EnemyScript>();
        seashellScript = GetComponentInParent<Seashell_EntityScript>();
    }

    private void AnimationFinishTrigger() => enemyScript.AnimationFinishedTriggerFunction();
    private void FireCastTrigger() => seashellScript.CastPearl();
}

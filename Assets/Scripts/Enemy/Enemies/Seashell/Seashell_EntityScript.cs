using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seashell_EntityScript : EnemyScript, IDamagable
{
    #region State Variables
    public Seashell_EnemyIdleState SeashellIdleState { get; private set; }
    public Seashell_EnemyAttackState SeashellAttackState { get; private set; }
    public Seashell_EnemyHurtState SeashellHurtState { get; private set; }
    public Seashell_EnemyOpenState SeashellOpenState { get; private set; }
    public Seashell_EnemyDeadState SeashellDeadState { get; private set; }
    #endregion
    public GameObject pearlObject;
    public GameObject firePoint;

    public Transform enemyDetectionObject;
    public LayerMask enemyCheck;

    protected override void Start()
    {
        base.Start();
        SeashellIdleState = new Seashell_EnemyIdleState(this, StateMachine, "idleState", this);
        SeashellAttackState = new Seashell_EnemyAttackState(this, StateMachine, "attackState", this);
        SeashellHurtState = new Seashell_EnemyHurtState(this, StateMachine, "hurtState", this);
        SeashellOpenState = new Seashell_EnemyOpenState(this, StateMachine, "openState", this);
        SeashellDeadState = new Seashell_EnemyDeadState(this, StateMachine, "deadState", this);

        StateMachine.Initialize(SeashellIdleState);

        EnemyHealth = _enemyData.Health;
        Flip();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool EnemyCheck()
    {
        return Physics2D.OverlapBox(enemyDetectionObject.position, new Vector2(6, 1), 0, enemyCheck);
    }

    public void CastPearl()
    {
        Instantiate(pearlObject, firePoint.transform);

    }

    public void TakeDamage()
    {
        if (StateMachine.CurrentState.canTakeDamage)
        {
            EnemyHealth--;
            StateMachine.ChangeState(SeashellHurtState);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(enemyDetectionObject.position, new Vector2(6, 1));
    }

}

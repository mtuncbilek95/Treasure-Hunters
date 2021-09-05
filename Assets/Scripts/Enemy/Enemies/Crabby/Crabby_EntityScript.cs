using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby_EntityScript : EnemyScript, IDamagable
{
    public Transform ledgeCheckObject;
    public Transform enemyDetectionObject;
    public LayerMask groundCheck;
    public LayerMask enemyCheck;
    
    public Crabby_EnemyIdleState CrabbyIdleState { get; private set; }
    public Crabby_EnemyMoveState CrabbyMoveState { get; private set; }
    public Crabby_EnemyHurtState CrabbyHurtState { get; private set; }
    public Crabby_EnemyDeadState CrabbyDeadState { get; private set; }
    public Crabby_EnemyAttackState CrabbyAttackState { get; private set; }

    protected override void Start()
    {
        base.Start();

        CrabbyIdleState = new Crabby_EnemyIdleState(this, StateMachine, "idleState", this);
        CrabbyMoveState = new Crabby_EnemyMoveState(this, StateMachine, "moveState", this);
        CrabbyHurtState = new Crabby_EnemyHurtState(this, StateMachine, "hurtState", this);
        CrabbyDeadState = new Crabby_EnemyDeadState(this, StateMachine, "deadState", this);
        CrabbyAttackState = new Crabby_EnemyAttackState(this, StateMachine, "attackState", this);

        StateMachine.Initialize(CrabbyIdleState);

        EnemyHealth = _enemyData.Health;
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public bool LedgeCheck()
    {
        return Physics2D.Raycast(ledgeCheckObject.position, Vector2.down, _enemyData.ledgeCheckLength, groundCheck);
    }
    public bool EnemyCheck()
    {
        return Physics2D.OverlapCircle(enemyDetectionObject.position, _enemyData.enemyRadius, enemyCheck);
    }
    public void TakeDamage()
    {
        if (StateMachine.CurrentState.canTakeDamage)
        {
            EnemyHealth--;
            StateMachine.ChangeState(CrabbyHurtState);
        }
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(ledgeCheckObject.position, Vector3.down * _enemyData.ledgeCheckLength);
        Gizmos.DrawWireSphere(enemyDetectionObject.position, _enemyData.enemyRadius);
    }
}

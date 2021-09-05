using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public GameObject AliveGO { get; private set; }

    [SerializeField] protected EnemyData _enemyData;

    public EnemyStateMachine StateMachine { get; private set; }

    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;
    public int EnemyHealth { get; protected set; }

    protected virtual void Start()
    {
        AliveGO = transform.Find("AliveGO").gameObject;

        Animator = AliveGO.GetComponent<Animator>();
        RB = AliveGO.GetComponent<Rigidbody2D>();

        StateMachine = new EnemyStateMachine();

        FacingDirection = 1;
    }

    protected virtual void Update()
    {
        RB.velocity = CurrentVelocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();

    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.y, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void Flip()
    {
        FacingDirection *= -1;
        AliveGO.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void AnimationFinishedTriggerFunction() => StateMachine.CurrentState.AnimationFinishedTrigger();
}

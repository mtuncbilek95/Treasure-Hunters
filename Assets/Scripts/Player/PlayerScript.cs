using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    #region Components
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInputHandler PlayerInput { get; private set; }

    [SerializeField] private PlayerDataScript playerData;

    #endregion

    #region State Variables
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerAirAttackState AirAttackState { get; private set; }
    public PlayerThrowSwordState ThrowSwordState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion

    #region Variables
    public Transform weaponEnemyCheckObject;

    public Transform groundCheckObject;
    public LayerMask groundCheck;
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;

    public Vector3 groundRaycastOffset;
    public static int FacingDirection { get; private set; }

    public int haveSword;
    public int attackCounter;
    private float attackTimer;
    public bool CanTakeSword { get; private set; }
    #endregion

    #region Unity Events
    public List<UnityEvent> unityEvents;

    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idleState");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "moveState");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAirState");
        LandState = new PlayerLandState(this, StateMachine, playerData, "groundedState");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAirState");
        AttackState = new PlayerAttackState(this, StateMachine, playerData, "attackState");
        AirAttackState = new PlayerAirAttackState(this, StateMachine, playerData, "airAttackState");
        ThrowSwordState = new PlayerThrowSwordState(this, StateMachine, playerData, "throwState");
        HurtState = new PlayerHurtState(this, StateMachine, playerData, "hurtState");
        DeadState = new PlayerDeadState(this, StateMachine, playerData, "deadState");
    }
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        PlayerInput = GetComponent<PlayerInputHandler>();

        FacingDirection = 1;
        haveSword = -1;
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.canTakeSword = CanTakeSword;
        StateMachine.CurrentState.LogicUpdate();
        SetTimer();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Check Functions
    public bool GroundCheck()
    {
        return Physics2D.Raycast(groundCheckObject.position - groundRaycastOffset, Vector2.down, playerData.groundCheckLength, groundCheck) ||
            Physics2D.Raycast(groundCheckObject.position + groundRaycastOffset, Vector2.down, playerData.groundCheckLength, groundCheck);
    }

    public void CheckFlip(int xInput)
    {
        if (xInput != 0 && FacingDirection != xInput)
        {
            Flip();
        }
    }

    #endregion

    #region Set Functions
    public void SetDamage()
    {
        Collider2D[] enemyList = Physics2D.OverlapCircleAll(weaponEnemyCheckObject.position, playerData.weaponRadius);
        foreach (var collider in enemyList)
        {
            IDamagable enemy = collider.GetComponentInParent<IDamagable>();
            if(enemy != null)
            {
                enemy.TakeDamage();
            }
            
        }
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
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void SetTimer()
    {
        if (attackCounter == 1)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 0.5f)
            {
                attackTimer = 0;
                attackCounter = 0;
            }
        }
        else if (attackCounter == 2)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 0.5f)
            {
                attackTimer = 0;
                attackCounter = 0;
            }
        }

    }
    #endregion

    #region Extra Unity Functions
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundCheckObject.position + groundRaycastOffset, groundRaycastOffset + groundCheckObject.position + Vector3.down * playerData.groundCheckLength);
        Gizmos.DrawLine(groundCheckObject.position - groundRaycastOffset, groundCheckObject.position - groundRaycastOffset + Vector3.down * playerData.groundCheckLength);
        Gizmos.DrawWireSphere(weaponEnemyCheckObject.position, playerData.weaponRadius);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Sword")
        {
            CanTakeSword = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Sword")
        {
            CanTakeSword = false;
        }
    }
    private void AnimationTriggerFunction() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishedTriggerFunction() => StateMachine.CurrentState.AnimationFinishedTrigger();
    private void EventTriggerFunction() => unityEvents[1]?.Invoke();

    #endregion
}

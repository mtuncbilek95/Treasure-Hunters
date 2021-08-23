using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region Components
    public PlayerStateMachine StateMachine { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInputHandler PlayerInput { get; private set; }
    public PlayerStateEventTrigger CheckScript { get; private set; }

    [SerializeField] private PlayerDataScript playerData;
    #endregion

    #region State Variables
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMovementState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerAirAttackState AirAttackState { get; private set; }
    public PlayerThrowSwordState ThrowSwordState { get; private set; }
    public PlayerHurtState HurtState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        CheckScript = GetComponent<PlayerStateEventTrigger>();
        IdleState = new PlayerIdleState(this, CheckScript, StateMachine, playerData, "idleState");
        MoveState = new PlayerMovementState(this, CheckScript, StateMachine, playerData, "moveState");
        JumpState = new PlayerJumpState(this, CheckScript, StateMachine, playerData, "inAirState");
        LandState = new PlayerLandState(this, CheckScript, StateMachine, playerData, "groundedState");
        InAirState = new PlayerInAirState(this, CheckScript, StateMachine, playerData, "inAirState");
        AttackState = new PlayerAttackState(this, CheckScript, StateMachine, playerData, "attackState");
        AirAttackState = new PlayerAirAttackState(this, CheckScript, StateMachine, playerData, "airAttackState");
        ThrowSwordState = new PlayerThrowSwordState(this, CheckScript, StateMachine, playerData, "throwState");
        HurtState = new PlayerHurtState(this, CheckScript, StateMachine, playerData, "hurtState");
        DeadState = new PlayerDeadState(this, CheckScript, StateMachine, playerData, "deadState");

        StateMachine = new PlayerStateMachine();

    }
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        PlayerInput = GetComponent<PlayerInputHandler>();

        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
}

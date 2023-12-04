using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerWalkingState WalkingState { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerTrottingState TrottingState { get; private set; }
    public PlayerCanterState CanterState { get; private set; }
    public PlayerGallopState GallopState { get; private set; }
    public PlayerHardStoppingState HardStoppingState { get; private set; }
    public PlayerSoftStoppingState SoftStoppingState { get; private set; }

    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }

    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkingState = new PlayerWalkingState(this, StateMachine, playerData, "walking");
        TrottingState = new PlayerTrottingState(this, StateMachine, playerData, "trotting");
        CanterState = new PlayerCanterState(this, StateMachine, playerData, "canter");
        GallopState = new PlayerGallopState(this, StateMachine, playerData, "gallop");
        HardStoppingState = new PlayerHardStoppingState(this, StateMachine, playerData, "hardStopping");
        SoftStoppingState = new PlayerSoftStoppingState(this, StateMachine, playerData, "softStopping");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
        Debug.Log(InputHandler.InteractDoubleClick);
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
}

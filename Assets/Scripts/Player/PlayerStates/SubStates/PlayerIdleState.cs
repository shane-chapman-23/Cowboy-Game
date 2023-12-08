using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerOnHorseState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        //Sets the velocity and the lastXInput to 0 when entering the idle state
        //this is to prevent the player from moving when entering the idle state
        player.SetVelocityX(0f);
        lastXInput = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    } 

    //If there is a movement input by the player, change to walking state.
    //If the input is not equal to the players facing direction, change to turning state.
    private void HandleInput()
    {
        if (xInput != player.FacingDirection && xInput != 0)
        {
            stateMachine.ChangeState(player.TurningState);
        } 
        else if (xInput == player.FacingDirection)
        {
            stateMachine.ChangeState(player.WalkingState);
        }
    }
}

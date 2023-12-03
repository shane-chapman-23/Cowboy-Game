using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerOnHorseState : PlayerState
{

    protected int xInput;
    protected int lastXInput;
    protected bool interactInput;


    protected float movementStateChangeCooldownTimer;
    protected float movementStateChangeCooldownDelay = 0.2f;

    protected float postInputMovementDurationTimer;
    protected float postInputMovementDuration = 1f;

    public PlayerOnHorseState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        
        //reset movementStateChangeCooldownTimer when entering a new movement state
        movementStateChangeCooldownTimer = 0;

    }

    public override void Exit()
    {
        base.Exit(); 
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        interactInput = player.InputHandler.InteractInput;

        //starts the movementStateChangeCooldownTimer
        movementStateChangeCooldownTimer += Time.deltaTime;

        //if the player is holding movement key, set lastXInput to the current xInput and reset the postInputMovementDurationTimer
        //else if the player is not holding a movement key, start the postInputMovementDurationTimer
        if (xInput != 0)
        {
            lastXInput = xInput;
            postInputMovementDurationTimer = 0;
        } 
        else
        {
            postInputMovementDurationTimer += Time.deltaTime;
        }

        

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    //Sets the velocity of the player
    //if player is moving the same direciton they are inputting, allow the player to move.
    //Checks whether the xInput has a value, if it does, set the velocity to the speed * xInput. if not, velocity is set to speed * lastXInput
    //if using the lastXInput, the player will continue to move in the direction they are moving until the postInputMovementDurationTimer is finished
    public void SetMovementSpeed(float speed)
    {
        if (player.CurrentVelocity.x >= 0 && lastXInput > 0) 
        {
            player.SetVelocityX(speed * (xInput != 0 ? xInput : lastXInput));
        } 
        else if (player.CurrentVelocity.x <= 0 && lastXInput < 0)
        {
            player.SetVelocityX(speed * (xInput != 0 ? xInput : lastXInput));
        }
    }

    //Sets the deceleration speed of the player
    public void SetDecelerationSpeed(float deceleration)
    {
        float newVelocityX = player.CurrentVelocity.x - Math.Sign(player.CurrentVelocity.x) * deceleration * Time.deltaTime;

        player.SetVelocityX(newVelocityX);

        Debug.Log(newVelocityX);
    }

    //if the player is moving and there is no input a timer will start, once the timer reachers the postInputMovementDuration, change to the previous movement state
    //giving the horse a somewhat realistic transition when slowing down
    //may need to change the names to better reflect what the timer is actually doing
    public void NoInputStateChange(PlayerState newState)
    {
        if (postInputMovementDurationTimer >= postInputMovementDuration)
        {
            stateMachine.ChangeState(newState);
        }
    }

    //if the player is pushing a movement key and hits the interact key, change to the next state.
    //Also using a timer to prevent players from changing states too quickly.
    public void SpeedIncreaseStateChange(PlayerState newState)
    {
        if (xInput != 0 && interactInput && movementStateChangeCooldownTimer >= movementStateChangeCooldownDelay)
        {
            stateMachine.ChangeState(newState);
        }
    }

    //If the player is moving and pushes the opposite direction, change to one of the stopping states
    public void PlayerStoppingStateChange(PlayerState newState)
    {
        if (Math.Sign(player.CurrentVelocity.x) != Math.Sign(xInput))
        {
            stateMachine.ChangeState(newState);
        }
    }

    //checks where the player is moving slower than the stopVelocityThreshold, is so, change to idle state
    public void StoppingToIdleStateTransition()
    {
        if (Math.Abs(player.CurrentVelocity.x) <= playerData.stopVelocityThreshold)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}

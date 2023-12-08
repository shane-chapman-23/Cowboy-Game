using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerOnHorseState
{


    public PlayerWalkingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        // GameObject.FindObjectOfType<AudioManager>().Play("horseWalkingDirt");
    }

    public override void Exit()
    {
        base.Exit();

        // GameObject.FindObjectOfType<AudioManager>().Stop("horseWalkingDirt");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        

        SetMovementSpeed(playerData.walkingVelocity);

        NoInputStateChange(player.IdleState);

        SpeedIncreaseStateChange(player.TrottingState);

        ChangeToStoppingStateCheck(player.SoftStoppingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

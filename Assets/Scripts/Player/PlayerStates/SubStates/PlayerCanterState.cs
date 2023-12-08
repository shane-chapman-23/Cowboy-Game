using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanterState : PlayerOnHorseState
{

    public PlayerCanterState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        // GameObject.FindObjectOfType<AudioManager>().Play("horseCanterDirt");

    }

    public override void Exit()
    {
        base.Exit();
        // GameObject.FindObjectOfType<AudioManager>().Stop("horseCanterDirt");

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetMovementSpeed(playerData.canterVelocity);

        NoInputStateChange(player.TrottingState);

        SpeedIncreaseStateChange(player.GallopState);

        ChangeToStoppingStateCheck(player.SoftStoppingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}


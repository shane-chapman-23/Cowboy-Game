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

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetMovementSpeed(playerData.canterVelocity);

        NoInputStateChange(player.TrottingState);

        SpeedIncreaseStateChange(player.GallopState);

        PlayerStoppingStateChange(player.SoftStoppingState);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}


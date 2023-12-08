using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrottingState : PlayerOnHorseState
{
    public PlayerTrottingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        // GameObject.FindObjectOfType<AudioManager>().Play("horseTrottingDirt");

    }

    public override void Exit()
    {
        base.Exit();
        // GameObject.FindObjectOfType<AudioManager>().Stop("horseTrottingDirt");

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetMovementSpeed(playerData.trottingVelocity);

        NoInputStateChange(player.WalkingState);

        SpeedIncreaseStateChange(player.CanterState);

        ChangeToStoppingStateCheck(player.SoftStoppingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGallopState : PlayerOnHorseState
{
    public PlayerGallopState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        // GameObject.FindObjectOfType<AudioManager>().Play("horseGallopingDirt");

    }

    public override void Exit()
    {
        base.Exit();
        // GameObject.FindObjectOfType<AudioManager>().Stop("horseGallopingDirt");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        SetMovementSpeed(playerData.gallopVelocity);

        NoInputStateChange(player.CanterState);

        ChangeToStoppingStateCheck(player.HardStoppingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

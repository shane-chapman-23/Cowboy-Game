using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardStoppingState : PlayerOnHorseState
{
    public PlayerHardStoppingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {

    }

    public override void Enter()
    {
       player.Anim.SetBool("hardStopping", true);
    }

    public override void Exit()
    {
        player.Anim.SetBool("hardStopping", false);
    }

    public override void LogicUpdate()
    {
        SetDecelerationSpeed(playerData.hardDecelerationSpeed);

        StoppingToIdleStateTransition();
    }

    public override void PhysicsUpdate()
    {

    }
}

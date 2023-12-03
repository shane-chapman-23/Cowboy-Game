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

    }

    public override void Exit()
    {

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

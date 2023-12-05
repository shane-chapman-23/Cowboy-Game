using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurningState : PlayerOnHorseState
{

    public PlayerTurningState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        // if (player.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
        // {
        //     OnTurnAnimationEnd();
        // }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.rb.velocity.y == 0)
            player.stateMachine.ChangeState(player.idleState);

        if (player.canDoubleJump && Input.GetButtonDown("Jump"))
            player.stateMachine.ChangeState(player.doubleJumpState);

        if (player.playerDetected.CheckWall())
            player.stateMachine.ChangeState(player.wallState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerState
{
    public PlayerDoubleJumpState(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.rb.velocity.x, player.doubleJumpForce);
        player.canDoubleJump = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.rb.velocity.y <= 0)
            player.stateMachine.ChangeState(player.airState);
    }
}

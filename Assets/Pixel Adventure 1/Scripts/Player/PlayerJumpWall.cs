using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpWall : PlayerJumpState
{
    public PlayerJumpWall(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity(-5 * player.rb.velocity.x*player.facingRight, player.doubleJumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.stateMachine.ChangeState(player.airState);
    }
}

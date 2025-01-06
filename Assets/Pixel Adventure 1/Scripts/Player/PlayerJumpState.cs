using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.rb.velocity.x, player.jumpForce);
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

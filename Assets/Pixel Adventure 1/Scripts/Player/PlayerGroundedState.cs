using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.canDoubleJump = false;
    }

    public override void Exit()
    {
        base.Exit();
        player.canDoubleJump = true;
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetButtonDown("Jump"))
            player.stateMachine.ChangeState(player.jumpState);
        if (player.rb.velocity.y != 0)
            player.stateMachine.ChangeState(player.airState);
    }
}

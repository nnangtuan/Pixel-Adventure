using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerState
{
    public PlayerWallState(Player _player, PlayerStateMachine _machine, string _nameBool) : base(_player, _machine, _nameBool)
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
        player.SetVelocity(player.rb.velocity.x, player.rb.velocity.y*0.5f);

        if (Input.GetButtonDown("Jump"))
            player.stateMachine.ChangeState(player.jumpWall);

        if(!player.playerDetected.CheckWall())
            player.stateMachine.ChangeState(player.airState);
    }
}

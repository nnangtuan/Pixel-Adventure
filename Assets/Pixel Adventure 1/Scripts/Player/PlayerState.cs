using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
    public PlayerStateMachine machine;
    public string nameState;
    

    protected float xInput;
    protected float yInput;
    public PlayerState(Player _player, PlayerStateMachine _machine, string _nameBool)
    {
        player = _player;
        machine = _machine;
        nameState = _nameBool;
    }

    public virtual void Enter()
    {
        Debug.Log(nameState);
        player.anim.SetBool(nameState, true);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(nameState, false);
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.SetVelocity(xInput * player.moveSpeed, player.rb.velocity.y);
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
        
        
    }


}

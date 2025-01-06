using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get=> instance;}

    [Header(" Move info ")]
    public float moveSpeed;
    public float doubleJumpForce;
    public float jumpForce;
    public bool facingDir = true;
    public int facingRight=-1;
    public bool canDoubleJump;
   

    [Header(" Component ")]
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerStateMachine stateMachine;
    public PlayerDetected playerDetected;

    public PlayerIdleState idleState { get; private set; }
    public PlayerRunState runState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDoubleJumpState doubleJumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallState wallState { get; private set; }
    public PlayerJumpWall jumpWall { get; private set; }

    private void Awake()
    {

        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        runState = new PlayerRunState(this, stateMachine, "Run");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        doubleJumpState = new PlayerDoubleJumpState(this, stateMachine, "DoubleJump");
        wallState = new PlayerWallState(this, stateMachine, "Wall");
        jumpWall = new PlayerJumpWall (this, stateMachine, "Jump");

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerDetected = GetComponent<PlayerDetected>();
        
        stateMachine.Initialize(idleState);
    }
    private void Update()
    {;
        stateMachine.currentState.Update();
        
    }
    public void SetVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
        FlipController(x);
    }
    public void Flip()
    {
        facingDir = !facingDir;
        facingRight *= -1;
        float x = transform.localScale.x*-1;
        transform.localScale = new Vector3(x,transform.localScale.y, transform.localScale.z);
    }
    public void FlipController(float _x)
    {
        if (_x < 0 && facingDir)
            Flip();
        else if (_x > 0 && !facingDir)
            Flip();
    }

}
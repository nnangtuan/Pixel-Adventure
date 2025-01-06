using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetected : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject checkGrounded;
    [SerializeField] private GameObject checkWall;


    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float distanceToGround;
    [SerializeField] private float distanceToWall;

    public bool CheckGrounded()
    {
        return Physics2D.Raycast(checkGrounded.transform.position, Vector3.down, distanceToGround, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(checkGrounded.transform.position, checkGrounded.transform.position + new Vector3(0, -distanceToGround, 0));
        Gizmos.DrawLine(checkWall.transform.position, checkWall.transform.position+ new Vector3(distanceToWall, 0, 0)* -player.facingRight);
    }
    public bool CheckWall()
    {
        return Physics2D.Raycast(checkWall.transform.position, Vector3.left*player.facingRight, distanceToWall, whatIsGround);
    }
}

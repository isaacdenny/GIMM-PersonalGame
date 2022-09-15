using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : State
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckRadius = .1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float fallGravityScale = 5f;

    public override void Enter()
    {
        base.Enter();
        PlayerBrain.rb.gravityScale = fallGravityScale;
        PlayerBrain.animator.SetTrigger("Fall");
    }
    internal float AirMove(float moveX)
    {
        PlayerBrain.rb.velocity = new Vector3(moveX * PlayerRun.moveSpeed, PlayerBrain.rb.velocity.y, 0f);
        return moveX;
    }

    public override void Do()
    {
        if (PlayerBrain.airControlEnabled)
        {
            AirMove(PlayerInputHandler.CheckForMovementInput());
        }

        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask))
        {
            complete = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    
    [SerializeField] private float jumpForce;
    
    public const float FALLDEADZONE = -0.01f;

    public override void Enter()
    {
        base.Enter();
        PlayerBrain.rb = PlayerBrain.instance.GetComponent<Rigidbody2D>();
        PlayerBrain.rb.gravityScale = 3f;
        Jump();
    }

    internal void Jump()
    {
        PlayerBrain.rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
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
        if (PlayerBrain.rb.velocity.y <= FALLDEADZONE)
        {
            complete = true;
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
}

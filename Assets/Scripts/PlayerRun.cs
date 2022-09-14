using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : State
{
    public float moveSpeed = 10f;

    Rigidbody2D rb;



    internal float Move(float moveX)
    {
        
        rb.velocity = new Vector3(moveX * moveSpeed, rb.velocity.y, 0f);
        return moveX;
    }

    public override void Enter()
    {
        base.Enter();
        rb = PlayerBrain.instance.transform.GetComponent<Rigidbody2D>();
    }
    public override void Do()
    {
        
        base.Do();
        if (Move(PlayerInputHandler.CheckForMovementInput()) < PlayerInputHandler.INPUTDEADZONE)
        {
            PlayerBrain.instance.Set(PlayerBrain.instance.playerIdle);
        }
        if (PlayerInputHandler.CheckForJumpInput())
        {
            PlayerBrain.instance.Set(PlayerBrain.instance.playerJump);
        }
    }
}

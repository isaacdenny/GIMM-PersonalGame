using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerRun : State
{
    public static float moveSpeed = 10f;

    internal float Move(float moveX)
    {
        
        PlayerBrain.rb.velocity = new Vector3(moveX * moveSpeed, PlayerBrain.rb.velocity.y, 0f);
        return moveX;
    }

    public override void Enter()
    {
        base.Enter();
        PlayerBrain.animator.SetTrigger("Run");
        PlayerBrain.rb.gravityScale = 0f;
    }
    public override void Do()
    {
        
        if (Mathf.Abs(Move(PlayerInputHandler.CheckForMovementInput())) < PlayerInputHandler.INPUTDEADZONE)
        {
            PlayerBrain.instance.Set(PlayerBrain.instance.playerIdle);
        }
        if (PlayerInputHandler.CheckForJumpInput())
        {
            PlayerBrain.instance.Set(PlayerBrain.instance.playerJump);
        }
    }
}

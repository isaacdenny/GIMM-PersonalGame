using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerRun : State
{
    public static float moveSpeed = 10f;

    internal Vector2 Move(Vector2 move)
    {
        
        PlayerBrain.rb.velocity = move * moveSpeed;
        return move;
    }

    public override void Enter()
    {
        base.Enter();
        PlayerBrain.animator.SetTrigger("Run");
        PlayerBrain.rb.gravityScale = 0f;
    }
    public override void Do()
    {
        
        if (Move(PlayerInputHandler.CheckForMovementInput()).magnitude < PlayerInputHandler.INPUTDEADZONE)
        {
            PlayerBrain.Instance.Set(PlayerBrain.Instance.playerIdle);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State
{

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
        PlayerBrain.rb.gravityScale = 0f;
        PlayerBrain.animator.SetTrigger("Idle");
    }

    public override void Do()
    {
        base.Do();
        if (PlayerInputHandler.CheckForMovementInput().magnitude != 0)
        {
            PlayerBrain.instance.Set(PlayerBrain.instance.playerRun);
        }
    }
}

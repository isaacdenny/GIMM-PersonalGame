using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State
{

    // Start is called before the first frame update
    public override void Enter()
    {
        base.Enter();
    }

    public override void Do()
    {
        if (PlayerInputHandler.CheckForMovementInput().magnitude != 0)
        {
            complete = true;
        }
    }
}

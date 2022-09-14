using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : StateMachine
{
    public State playerJump, playerDash, playerIdle, playerFall, playerRun;

    public static PlayerBrain instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(instance);
            instance = this;
        }
    }

    private void Start()
    {
        state = playerIdle;
    }


    void Update()
    {
        StateUpdate();
    }

    private void FixedUpdate()
    {
        StateFixedUpdate();
    }

    public override void SetNextState()
    {
        if (state == playerJump)
        {
            Set(playerFall);
        }
        else if (state == playerRun)
        {
            Set(playerIdle);
        }
        else if (state == playerFall)
        {
            Set(playerIdle);
        }
        else if (state == playerIdle)
        {
            Set(playerRun);
        }

        
    }
}

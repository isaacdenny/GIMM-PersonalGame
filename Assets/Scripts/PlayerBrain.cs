using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerBrain : StateMachine
{
    public State playerDash, playerIdle, playerRun, playerDead, playerStun;

    public static PlayerBrain Instance { get; private set; }
    public static Rigidbody2D rb { get; private set; }
    public static Animator animator { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(Instance);
            Instance = this;
        }
    }

    private void Start()
    {
        state = playerIdle;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (state == playerRun)
        {
            Set(playerIdle);
        }
        else if (state == playerIdle)
        {
            Set(playerRun);
        }
    }
}

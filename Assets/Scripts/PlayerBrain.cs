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
    
    [SerializeField] private Animator animator;

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
            animator.SetTrigger("Idle");
        }
        else if (state == playerIdle)
        {
            Set(playerRun);
            animator.SetTrigger("Run");
        }
    }
}

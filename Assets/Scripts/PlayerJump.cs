using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    Rigidbody2D rb;
    [SerializeField] private float jumpForce;

    public const float FALLDEADZONE = -0.1f;

    public override void Enter()
    {
        base.Enter();
        rb = PlayerBrain.instance.GetComponent<Rigidbody2D>();
        Jump();
    }

    internal void Jump()
    {
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    public override void Do()
    {
        if (rb.velocity.y < FALLDEADZONE)
        {
            complete = true;
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
}

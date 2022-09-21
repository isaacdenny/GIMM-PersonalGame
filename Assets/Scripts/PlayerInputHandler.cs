using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputHandler
{
    public const float INPUTDEADZONE = 0.1f;

    public static Vector2 CheckForMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveX) >= INPUTDEADZONE || Mathf.Abs(moveY) >= INPUTDEADZONE)
        {
            Vector2 move = new Vector2(moveX, moveY);
            return move;
        }
        else
        {
            return Vector2.zero;
        }
    }

    public static bool CheckForShootInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

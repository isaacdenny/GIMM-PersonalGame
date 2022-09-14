using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputHandler
{
    public const float INPUTDEADZONE = 0.1f;

    // Update is called once per frame

    public static bool CheckForJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        return false;
    }

    public static bool CheckForShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
    public static float CheckForMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(moveX) >= INPUTDEADZONE)
        {
            return moveX;
        }

        return 0f;
    }
}

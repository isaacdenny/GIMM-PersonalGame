using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInputHandler
{
    public const float INPUTDEADZONE = 0.1f;

    // Update is called once per frame

    /*
    public static bool CheckForJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        return false;
    }*/

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

    /*
    public static Vector2Int CheckForAimInput()
    {
        float aimY = Input.GetAxisRaw("Vertical");

        if (aimY > INPUTDEADZONE)
        {
            return Vector2Int.up;
        }
        else if (aimY < INPUTDEADZONE)
        {
            return Vector2Int.down;
        }
        else return Vector2Int.zero;
    }
    */

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
